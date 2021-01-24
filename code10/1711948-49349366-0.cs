    public class Rootobject
    {
       // do List<CurrencyDetail> if you are expecting multiple element
        public CurrencyDetail btc_usd { get; set; }
        public CurrencyDetail eth_usd { get; set; }
        public CurrencyDetail doge_usd { get; set; }
        public CurrencyDetail pac_usd { get; set; }
        public CurrencyDetail rdd_usd { get; set; }
    }
    
    public class CurrencyDetail
    {
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
