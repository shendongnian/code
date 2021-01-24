    public class Item1
    {
        public string date { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Object1
    {
        public List<Item1> items { get; set; }
    }
    public class Item2
    {
        public string date { get; set; }
        public int id { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string Weight { get; set; }
    }
    public class Object2
    {
        public List<Item2> items { get; set; }
    }
    public class Item
    {
        public string date { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string Weight { get; set; }
    }
    public class Result
    {
        public List<Item> items { get; set; }
    }
