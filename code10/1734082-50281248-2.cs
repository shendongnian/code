    class StockMarket
    {
        public List<Company> Companies { get; set; }
        public StockMarket()
        {
            Companies = new List<Company>();
        
        }
        public StockMarket someMethod()
        {
            //You can change the state here
            StockMarket s = new StockMarket();
            s.Companies.Add(new Company(this.GetType(), "aa", "_", 123, 1234));
            return s;
        }
        //...
    }
