    interface IPowerup {
        int Cooldown { get; set; }
    }
    class Freeze : IPowerup {
        public Freeze() { Cooldown = 1; }
        private static int _cooldown;
        public int Cooldown { get { return _cooldown } set { _cooldown = value; }
    }
    class Burn : IPowerup {
        public Burn() { Cooldown = 2; }
        private static int _cooldown;
        public int Cooldown { get { return _cooldown } set { _cooldown = value; }
    }
