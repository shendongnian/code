    namespace Cards
    {
    	class PlayingCard
    	{
            private readonly Suit suit;
            private readonly Value value;
    
    		public PlayingCard(Suit s, Value v)
    		{
    			this.suit = s;
    			this.value = v;
    		}
        }
    }
