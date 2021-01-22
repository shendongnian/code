    public class Card
    {
        public enum Suit { Clubs, Diamonds, Spades, Hearts }
        public enum Rank { Two, Three, ...  King, Ace }
    
        public struct CardStruct
        {
            public Card.Suit Suit { get; private set; }
            public Card.Rank Rank { get; private set; }
        }
        
        public CardStruct Card {get; set;}
    
        public int Value
        {
            get    
            {
                switch((Suit)Card.Suit)
                {
                    case Suit.Hearts:   return Card.Rank + 0*14;
                    case Suit.Clubs:    return Card.Rank + 1*14;
                    case Suit.Diamonds: return Card.Rank + 2*14;
                    case Suit.Spades:   return Card.Rank + 3*14;                
                }
            }
        }
    }
