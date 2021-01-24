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
