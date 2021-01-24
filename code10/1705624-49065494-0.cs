    public class Stat
    {
        public string profitability_above_ltc { get; set; }
        public string price { get; set; }
        public string profitability_ltc { get; set; }
        public int algo { get; set; }
        public string speed { get; set; }
        public string profitability_btc { get; set; }
        public string profitability_above_btc { get; set; }
        public string profitability_eth { get; set; }
        public string profitability_above_eth { get; set; }
    }
    public class Result
    {
        public List<Stat> stats { get; set; }
    }
    public class RootObject
    {
        public Result result { get; set; }
        public string method { get; set; }
    }
    
    RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject>(json);
    //deserializedProduct.Result[i].price  <-- this is what you want.
