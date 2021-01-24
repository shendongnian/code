    public class ExchangeRatesResponse
      public ExchangeRateResult result { get; set; }
      public string error { get; set; }
    }
    
    public class ExchangeRateResult
    {
      public ExchangeRateItem BTC { get; set; }
      public ExchangeRateItem LTC { get; set; }
      public ExchangeRateItem USD { get; set; }
      public ExchangeRateItem CAD { get; set; }
      public ExchangeRateItem MAID { get; set; }
      public ExchangeRateItem XMR { get; set; }
      public ExchangeRateItem LTCT { get; set; }
    }
    
    public class ExchangeRateItem
    {
        public string is_fiat { get; set; }
        public decimal rate_btc { get; set; }
        public int last_update { get; set; }
        public string name { get; set; }
        public int confirms { get; set; }
    }
