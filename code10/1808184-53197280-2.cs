    public class Game
    {
        // Public properties
        public byte[,] BingoCard = new byte[5, 5];
        public string PlayerName { get; set; }
        // Constructors
        public Game() { }
        public Game(string pN)
        {
            PlayerName = pN;            
        }
    }
