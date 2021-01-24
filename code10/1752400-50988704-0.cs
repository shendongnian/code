    public sealed class GameVariables 
    {
        private static readonly _instance = new GameVariables();
        public static GameVariables Intance { get { return _instance; } }
        private GameVariables()
        {
            Reset();
        }
        public void Reset()
        {
           //Initialize your variables here when you start a new game
           PlayerHealth = 100;
           PlayerPosition = 0f;
           TotalScore = 0;
           [...]
        }
        public int PlayerHealth { get; set; }
        public float PlayerPosition { get; set; }
        public int TotalScore { get; set; }
        [...]
    }
