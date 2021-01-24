    class Card
    {
        private readonly int suit;
        private readonly int rank;
        public Card(int suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
        public int Suit { get { return suit; } }
        public int Rank{ get { return rank; } }
    }
