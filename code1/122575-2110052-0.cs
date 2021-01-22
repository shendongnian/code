    class Position
    {
        public bool Offensive { get; private set; }
        public bool Defensive { get; private set; }
        private Possition()
        {
            Offensive = false;
            Defensive = false;
        }
        public static readonly Position Quarterback = new Position() { Offensive = true };
        public static readonly Position Runningback = new Position() { Offensive = true };
        public static readonly Position DefensiveEnd = new Position() { Defensive = true };
        public static readonly Position Linebacker = new Position() { Defensive = true };
    }
