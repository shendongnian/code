    interface IPowerup {
        int Cooldown { get; set; }
    }
    class Freeze : IPowerup {
        private static int _cooldown;
        public int Cooldown { get { return _cooldown } set { _cooldown = value; }
        public Freeze() { Cooldown = 1; }
    }
    class Burn : IPowerup {
        private static int _cooldown;
        public int Cooldown { get { return _cooldown } set { _cooldown = value; }
        public Burn() { Cooldown = 2; }
    }
