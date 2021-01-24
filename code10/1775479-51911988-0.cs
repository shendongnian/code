    public class Card : IComparable<Card>
            {
                public Card(string suit, int number)
                {
                    this.Suit = suit;
                    this.Number = number;
                }
    
                public string Suit { get; }
                public int Number { get; }
    
                public int CompareTo(Card other)
                {
                    return Number.CompareTo(other.Number);
                }
            }
    
            public class CardComparer : IComparer<Card>
            {
                public int Compare(Card x, Card y)
                {
                    int compResult = x.Suit.CompareTo(y.Suit);
                    if (compResult == 0)
                    {
                        compResult = x.Number.CompareTo(y.Number);
                    }
                    return compResult;
                }
            }
