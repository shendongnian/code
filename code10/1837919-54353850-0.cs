    interface IPowerup {
        int Cooldown { get; set; }
    }
    class Freeze : IPowerup {
        public Freeze() { Cooldown = 1; }
        public int Cooldown { get; set; }
    }
    class Burn : IPowerup {
        public Burn() { Cooldown = 2; }
        public int Cooldown { get; set; }
    }
