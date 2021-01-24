    public class Rates
    {
            public double SGD { get; set; }
    }
    
    public class Item
    {
        public Item()
        {
            rates = new Rates();
        }
        public string @base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
    }
