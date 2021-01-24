        class Deck
        {
            Card[] cards = new Card[52];
            // Call cards[i].GetFullName() if you want the name.
        }
        class Card
        {
            private Suit _suit;
            private Name _name;
            public Card(Suit suit, Name name)
            {
                _suit = suit;
                _name = name;
            }
            public string GetFullName()
            {
                return _name + " of " + _suit;
            }
        }
