    static class DeckExtensions {
    
        public static void Shuffle(this deck)
        {
            Random rnd = new Random();
            deck.DeckOfCards = deck.DeckOfCards.OrderBy(x => rnd.Next()).ToArray();
        }
    
    }
