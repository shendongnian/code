    void Main()
    {
        var deck = new Deck();
        deck.Shuffle();
        var cards = deck.Deal(1);
        foreach (var card in cards)
        {
            Console.WriteLine($"{card.Value} of {card.Suit}");
        }
    }
    
    public struct Card
    {
        public Card(string suit, string value)
        {
            this.Suit = suit;
            this.Value = value;
        }
        public readonly string Suit;
        public readonly string Value;
    }
    
    public class Deck
    {
        private const int _numSuits = 4;
        private const int _numValues = 13;
    
        private string[] _suits = new [] { "Clubs", "Diamonds", "Hearts", "Spades", };
        private string[] _values = new []
        {
            "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King",
        };
    
        private Card[] _deck = new Card[52];
    
        public Deck()
        {
            _deck =
                _suits
                    .SelectMany(s => _values, (s, v) => new Card(s, v))
                    .ToArray();
        }
    
        private Random _random = new Random();
        public void Shuffle()
        {
            _deck = _deck.OrderBy(_ => _random.Next()).ToArray();
        }
    
        public Card[] Deal(int take)
        {
            var cards = _deck.Take(take).ToArray();
            _deck = _deck.Skip(take).ToArray();
            return cards;
        }
    }
