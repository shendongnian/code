      enum Suit
      {
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3,
        Spades = 4
      }
      class Card
      {
        private static readonly Dictionary<string, int> rankMap = new Dictionary<string, int>()
        {
          {"2", 2 },
          {"3", 3 },
          {"4", 4 },
          {"5", 5 },
          {"6", 6 },
          {"7", 7 },
          {"8", 8 },
          {"9", 9 },
          {"10", 10 },
          {"Jack", 11 },
          {"Queen", 12 },
          {"King", 13 },
          {"Ace", 14 },
        };
        private Suit suit;
        private string rank;
        public Suit Suit => suit;
        public string Rank => rank;
        public int Value { get { return rankMap[rank]; } }
        public Card(Suit s, string r)
        {
          suit = s;
          rank = r;
        }
      }
