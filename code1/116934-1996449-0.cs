    class Hero
    {
        public string faction;
        public string name;
        public HeroType herotype; // <-- not a string
    
        enum HeroType
        {
            Agility,
            Strength,
            Intelligence,
        }
    }
