    class NormalDeck : Deck
    {
        // This would go in the NormalGame class to apply the enumerators to the values as a cipher.
        // Need int values for logic reasons (easier to work with numbers than J or K !!!
        // Also allows for most other methods to work with other deck<Type> (ex: Uno, Go Fish, Normal cards)
        public enum Suites
        {
            Hearts,
            Diamonds,
            Spades,
            Clover
        };
        // Same comment as above. 
        public enum Values
        { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
        public void NewNormalDeck()
        {
            // Clear the deck of cards
            if (this.cards != null)
            {
                Array.Clear(this.cards, 0, this.cards.Length);
            }
            //Set Value to length of Normal deck of Cards without Jokers 
            cards = new Card[52];
            // to keep count of which card we are.  
            int curNumofCards = 0;
            // Cycle through all of the suites listed in "suites" then all the values of     that suite
            for (int x = 0; x < Enum.GetValues(typeof(Suites)).GetLength(0); x++)
            {
                for (int y = 0; y < Enum.GetValues(typeof(Values)).GetLength(0); y++)
                {
                    Card newCard = new Card();
                    newCard.suite = x;
                    newCard.value = y;
                    this.cards[curNumofCards] = newCard;
                    curNumofCards++;
                }
            }
        }
    }
