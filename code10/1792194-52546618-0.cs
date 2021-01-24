    public static void Shuffle_b(Deck deck)
    {
        Deck x = new Deck();
        Deck y = new Deck();
        Deck z = new Deck();
        for (int i = 0; i < deck.Cards.Count; i++)
        {
            // Add one to i, then get the remainder from dividing it by 3
            int deckNo = (i + 1) % 3;
            // If the remainder is 1, use deck x; if it's 2 use deck y; else use deck z
            Deck addTo = (deckNo == 1) ? x : (deckNo == 2) ? y : z;
            // Add the card to our selected deck
            addTo.Cards.Add(deck.Cards[i]);
        }
        // Now x contains the cards from 'deck' at indexes: 0, 3, 6, 9, etc...
        // And y contains the cards from 'deck' at indexes: 1, 4, 7, 10, etc...
        // And z contains the cards from 'deck' at indexes: 2, 5, 8, 11, etc..
    }
