    public class Rootobject
    {
        public List<CurrencyDetail> currencies { get; set; }
    }
    
    public class CurrencyDetail
    {
        //btc_usd  or  eth_usd or doge_usd  or pac_usd 
        public string type { get; set; }
        public float high { get; set; }
        public int low { get; set; }
        public float avg { get; set; }
        public float vol { get; set; }
        public float vol_cur { get; set; }
        public float last { get; set; }
        public float buy { get; set; }
        public float sell { get; set; }
        public int updated { get; set; }
    }
