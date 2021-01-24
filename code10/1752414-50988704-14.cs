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
           TotalScore = 0;
           PlayerStates = new Dictionary<int, PlayerState>();
           [...]
        }
        public Dictionary<int, PlayerState> PlayerStates { get; private set; }
        public int TotalScore { get; set; }
        [...]
    }
