    public class Card
    {
        public enum Suit { Clubs, Diamonds, Spades, Hearts }
        public enum Rank { Two, Three, ...  King, Ace }
    
        public struct CardStruct
        {
            public Card.Suit Suit { get; private set; }
            public Card.Rank Rank { get; private set; }
        }
        
        //public CardStruct Card {get; set;} -can't be same as enclosing class either
        public CardStruct Identity {get; set;}
    
        public int Value
        {
            get    
            {
                //switch((Suit)Card.Suit)
                switch((Suit)Identity.Suit)
                {
                    //case Suit.Hearts:   return Card.Rank + 0*14;
                    case Suit.Hearts:   return Identity.Rank + 0*14;
                    case Suit.Clubs:    return Identity.Rank + 1*14;
                    case Suit.Diamonds: return Identity.Rank + 2*14;
                    case Suit.Spades:   return Identity.Rank + 3*14;                
                }
            }
        }
    }
