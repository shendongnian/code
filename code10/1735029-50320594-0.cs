    class Deck 
    {
        private Queue<Card> cards = new Queue<Card>();
        private readonly Random random = new Random();
        //This is for a standard deck, but you could make it work it your special deck
        //We just loop and make sure there is one of each possible card
        private virtual IEnumerable<Card> CreateFreshDeck()
        {
            for (var suit = 1; suit<=4; suit++)
                for (var val = 1; val <=13; val++)
                    yield return new Card(suit,val);
        }
        public void Shuffle()
        {
            this.cards = new Queue<Card>
            (
                CreateFreshDeck().OrderBy( a => random.Next() )  //This is where the shuffling happens
            );
        }
        public Card DealOne()
        {
            return this.cards.Dequeue();    
        }
    }
