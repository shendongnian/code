    class Deck 
    {
        private Queue<Card> cards = new Queue<Card>();  //Here's our queue
        private readonly Random random = new Random();
        //This is for a standard deck, but you could make it work it your special deck
        //We just loop and make sure there is one of each possible card
        private virtual IEnumerable<Card> CreateFreshDeck()
        {
            for (var suit = 1; suit<=4; suit++)
                for (var rank = 1; rank <=13; rank++)
                    yield return new Card(suit,rank);
        }
        public void Shuffle()
        {
            this.cards = new Queue<Card>
            (
                CreateFreshDeck().OrderBy( a => random.Next() )  //This is where the shuffling happens
            );
        }
        public int CardsRemaining
        {
            get { return cards.Count; }  
        }
        public Card DealOne()
        {
            return this.cards.Dequeue();    
        }
        public IEnumerable<Card> DealMany(int count)
        {
            return this.cards.Take(count);
        }
    }
