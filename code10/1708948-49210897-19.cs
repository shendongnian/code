    public class Hand
    {
        public Hand(params Card[] cards)
        {
            Cards = cards;
        }
        public Hand(string s)
        {
            // E.g. s = "8C TS KC 9H 4S"
            string[] parts = s.Split();
            Cards = parts
                .Select(p => new Card(p))
                .ToArray();
        }
        public Card[] Cards { get; }
        public bool IsRoyalFlush()
        {
            if (Cards[0].Rank != Rank.Ace) {
                return false;
            }
            for (int i = 1; i < Cards.Length; i++) {
                if (Cards[i - 1].Rank - Cards[i].Rank != 1) {
                    return false;
                }
            }
            return true;
        }
        //TODO: Add more scoring methods.
    }
