    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
        public Card(string s)
        {
            switch (s[0]) {
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    Rank = (Rank)(s[0] - '0');
                    break;
                case 'T':
                    Rank = Rank.Ten;
                    break;
                case 'J':
                    Rank = Rank.Jack;
                    break;
                case 'Q':
                    Rank = Rank.Queen;
                    break;
                case 'K':
                    Rank = Rank.King;
                    break;
                case 'A':
                    Rank = Rank.Ace;
                    break;
            }
            switch (s[1]) {
                case 'C':
                    Suit = Suit.Club;
                    break;
                case 'D':
                    Suit = Suit.Diamond;
                    break;
                case 'H':
                    Suit = Suit.Heart;
                    break;
                case 'S':
                    Suit = Suit.Spade;
                    break;
            }
        }
    }
