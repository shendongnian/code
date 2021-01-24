    public enum Suit { Hearts, Clubs, Diamonds, Spades}
    public enum CardName
    {
        Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
    public class Card
    { 
        public Suit Suit { get; }
        public CardName Name { get; }
        public int Value
        {
            get
            {
                var value = (int) Name;
                return value == 1 ? 11 : value > 9 ? 10 : value;
            }
        }
        public Card(CardName name, Suit suit)
        {
            Name = name;
            Suit = suit;
        }
        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }
    }
    public class Deck
    {
        private readonly List<Card> cards = new List<Card>();
        private readonly Random random = new Random();
        public int Count => cards.Count;
        public static Deck GetStandardDeck(bool shuffled)
        {
            var deck = new Deck();
            deck.ResetToFullDeck();
            if (shuffled) deck.Shuffle();
            return deck;
        }
        public void Add(Card card)
        {
            cards.Add(card);
        }
        public bool Contains(Card card)
        {
            return cards.Contains(card);
        }
        public bool Remove(Card card)
        {
            return cards.Remove(card);
        }
        public int Sum => cards.Sum(card => card.Value);
        public Card DrawNext()
        {
            var card = cards.FirstOrDefault();
            if (card != null) cards.RemoveAt(0);
            return card;
        }
        public void Clear()
        {
            cards.Clear();
        }
        public void ResetToFullDeck()
        {
            // Populate our deck with 52 cards
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardName name in Enum.GetValues(typeof(CardName)))
                {
                    cards.Add(new Card(name, suit));
                }
            }
        }
        public void Shuffle()
        {
            var thisIndex = cards.Count;
            while (thisIndex-- > 1)
            {
                var otherIndex = random.Next(thisIndex + 1);
                if (thisIndex == otherIndex) continue;
                var temp = cards[otherIndex];
                cards[otherIndex] = cards[thisIndex];
                cards[thisIndex] = temp;
            }
        }
    }
    class Program
    {
        private static void Main()
        {
            var deck = Deck.GetStandardDeck(true);
            var playerHand = new Deck();
            var computerHand = new Deck();
            Console.WriteLine("Each of us will draw 5 cards. " +
                "The one with the highest total wins.");
            for (int i = 0; i < 5; i++)
            {
                GetKeyFromUser($"\nPress any key to start round {i + 1}");
                var card = deck.DrawNext();
                Console.WriteLine($"\nYou drew a {card}");
                playerHand.Add(card);
                card = deck.DrawNext();
                Console.WriteLine($"I drew a {card}");
                computerHand.Add(card);
            }
            while (playerHand.Sum == computerHand.Sum)
            {
                Console.WriteLine("\nOur hands have the same value! Draw another...");
                var card = deck.DrawNext();
                Console.WriteLine($"\nYou drew a {card}");
                playerHand.Add(card);
                card = deck.DrawNext();
                Console.WriteLine($"I drew a {card}");
                computerHand.Add(card);
            }
            Console.WriteLine($"\nYour total is: {playerHand.Sum}");
            Console.WriteLine($"My total is: {computerHand.Sum}\n");
            Console.WriteLine(playerHand.Sum > computerHand.Sum
                ? "Congratulations, you're the winner!"
                : "I won this round, better luck next time!");
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
        private static ConsoleKeyInfo GetKeyFromUser(string prompt)
        {
            Console.Write(prompt);
            var key = Console.ReadKey();
            Console.WriteLine();
            return key;
        }
    }
