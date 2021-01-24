    public class Stats
    {
        public int power { get; set; }
        public int defence { get; set; }
        public int vitality { get; set; }
    }
    public class items
    {
        public int id { get; set; }
        public string title { get; set; }
        public int value { get; set; }
        public Stats stats { get; set; }
        public string description { get; set; }
        public bool stackable { get; set; }
        public int rarity { get; set; }
        public string slug { get; set; }
    }
