    public class Hero {
        public string Name { get; set; }
        public string HeroType { get; set; }
        public int StartingHP { get; set; }
        public int StartingMana { get; set; }
        public Dictionary<string, string> Spells { get; set; }
        public Dictionary<string, string> Items { get; set; } 
        public Image Portrait { get; set; }
    }
