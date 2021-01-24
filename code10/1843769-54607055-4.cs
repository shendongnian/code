        class Deck
        {
            private IList<Card> cards = new List<Card>();
            public Deck()
            {
                foreach (string rank in Enum.GetNames(typeof(Suit)))
                {
                    foreach (string value in Enum.GetNames(typeof(value)))
                    {
                        cards.Add(new Card(rank, value));
                    }
                }
            }
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
