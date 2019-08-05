using System;
using System.Collections.Generic;

namespace CustomCardSort
{
    class CardList
    {
        public string[] ValueList { get; }
        public string[] SuitList { get; }

        public CardList()
        {
            ValueList = new string[] { "2", "3", "4", "5",
                                       "6", "7", "8", "9",
                                       "10", "J", "Q", "K",
                                       "A" };
            SuitList = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };
        }
    }

    class Card : IComparable<Card>
    {
        public string Value { get; set; }
        public string Suit { get; set; }

        public Card(string v, string s)
        {
            Value = v;
            Suit = s;
        }

        public Card(int v, int s)
        {
            CardList list = new CardList();

            Value = list.ValueList[v];
            Suit = list.SuitList[s];
        }

        public int CompareTo(Card other)
        {
            CardList list = new CardList();

            int valueResult = Array.IndexOf(list.ValueList, Value) - Array.IndexOf(list.ValueList, other.Value);

            if (valueResult == 0)
            {
                return Array.IndexOf(list.SuitList, Suit) - Array.IndexOf(list.SuitList, other.Suit);
            }

            return valueResult;
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Card> testCards = GetTestData(100);
            testCards = CustomSort(testCards);
            PrintCardList(testCards);
            Console.WriteLine("-------------");
            testCards = CustomSort(testCards, true);
            PrintCardList(testCards);
            Console.ReadKey();
        }

        private static List<Card> CustomSort(List<Card> cards, bool decending = false)
        {
            cards.Sort();
            if (decending)
            {
                cards.Reverse();
            }
            return cards;
        }

        private static void PrintCardList(List<Card> cards)
        {
            foreach (Card c in cards)
            {
                Console.WriteLine($"{c.Value} of {c.Suit}");
            };
        }

        private static List<Card> GetTestData(int numCards)
        {
            List<Card> cardSet = new List<Card>();
            Random random = new Random();
            CardList list = new CardList();

            if (numCards < 0) numCards = 0;
            for (int i = 0; i < numCards; i++)
            {
                int v = random.Next(list.ValueList.Length);
                int s = random.Next(list.SuitList.Length);
                Card card = new Card(v, s);
                cardSet.Add(card);
            }

            return cardSet;
        }
    }
}
