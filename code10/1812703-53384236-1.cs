    class Program
    {
        static void Main(string[] args)
        {
            Deck.FillDeck();
            Deck.PrintDeck();
            Console.ReadLine(); 
        }
    }
    class Card
    {
        public int Value;
        public static string[] SuitsArray = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };
        public string Suit;
        public Card(int value, string suit)
        {
            Value = value;
            Suit = suit;
        }
        public Card(string input)
        {
            string tempValue = "";
            string suitSentence = "";
            switch (Value)
            {
                case 11:
                    tempValue = "Jack";
                    break;
                case 12:
                    tempValue = "Queen";
                    break;
                case 13:
                    tempValue = "King";
                    break;
                case 14:
                    tempValue = "Ace";
                    break;
                default:
                    tempValue = Value.ToString();
                    break;
            }
            switch (Suit)
            {
                case "Hearts":
                    suitSentence = " of Hearts";
                    break;
                case "Diamonds":
                    suitSentence = " of Diamonds";
                    break;
                case "Clubs":
                    suitSentence = " of Clubs";
                    break;
                case "Spades":
                    suitSentence = " of Spades";
                    break;
            }
            input = tempValue + suitSentence;
        }
    }
    class Deck
    {
        public static Card[] deck = new Card[52];
        public static void FillDeck()
        {
            int index = 0;
            foreach (string suit in Card.SuitsArray)
            {
                for (int value = 2; value <= 14; value++)
                {
                    Card card = new Card(value, suit);
                    deck[index] = card;
                    index++;
                }
            }
        }
        public static void PrintDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine($"{deck[i].Value} {deck[i].Suit}");
            }
        }
    }
