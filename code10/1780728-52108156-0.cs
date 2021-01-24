    public class Item_Partsfinder
    {
        public string sku { get; set; }
        public string name { get; set; }
        public Partsfinder partsfinder { get; set; }
    }
    
    public class Partsfinder
    {
       public List<string> lvl0 { get; set; }
    }
