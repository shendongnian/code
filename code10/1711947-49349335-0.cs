    class Program
    {
        static void Main(string[] args)
        {
            var array = "[{\"btc_usd\":[{\"high\":8550.0102,\"low\":7800,\"avg\":8175.0051,\"vol\":1615543.57397705,\"vol_cur\":197.54076079,\"last\":7850,\"buy\":7850.00000000,\"sell\":7879.00000000,\"updated\":1521383863}],\"eth_usd\":[{\"high\":622.93708559,\"low\":482,\"avg\":552.46854279,\"vol\":346598.40520112,\"vol_cur\":630.37075493,\"last\":488.27857735,\"buy\":489.77564548,\"sell\":492.11726255,\"updated\":1521383876}]}]";
            List<RootObject> a = JsonConvert.DeserializeObject<List<RootObject>>(array);
        }
    }
    public class RootCurrency
    {
        public double high { get; set; }
        public int low { get; set; }
        public double avg { get; set; }
        public double vol { get; set; }
        public double vol_cur { get; set; }
        public double last { get; set; }
        public double buy { get; set; }
        public double sell { get; set; }
        public int updated { get; set; }
    }
    
    public class RootObject
    {
        public List<RootCurrency> btc_usd { get; set; }
        public List<RootCurrency> eth_usd { get; set; }
    }
