    public class RootObject
    {
        public Contest contest { get; set; }
        public Contestants contestants { get; set; }
    }
    public class Contest
    {
        public string name { get; set; }
    }   
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public Stats stats { get; set; }
    }
    public class Stats
    {
        public int time { get; set; }
    }
    public class Contestants
    {
        public List<Player> player { get; set; }
    }
    
