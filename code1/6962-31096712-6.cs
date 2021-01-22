	class Pack
	{
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private PlayingCard[,] cardPack;
		public Pack()
		{
            this.cardPack = new PlayingCard[NumSuits, CardsPerSuit];
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }
		}
    }
