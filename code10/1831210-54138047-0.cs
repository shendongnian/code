    public class InitTxn
    {
        public string key { get; set; }
        public int orderid { get; set; }
        public long steamid { get; set; }
        public int appid { get; set; }
        public int itemcount { get; set; }
        public string language { get; set; }
        public string currency { get; set; }
        public List<int> itemid { get; set; }
        public List<int> qty { get; set; }
        public List<int> amount { get; set; }
        public List<string> description { get; set; }
    }
