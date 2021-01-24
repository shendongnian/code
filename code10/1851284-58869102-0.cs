     class Card
     {
        //CREATE OUR RANK ENUM
        public enum SUIT
        {
            HEARTS,
            DIAMONDS,
            SPADES,
            CLUBS
        }
     
        public enum RANK
        {
            TWO , THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, 
            TEN, JACK, QUEEN, KING, ACE
        }
        
        
        public SUIT MySuit { get; set; }
        public RANK MyRank { get; set; }
        
    }
