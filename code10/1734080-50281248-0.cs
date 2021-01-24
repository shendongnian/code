    class Company
    {
        public Company(Type type,string name,string symbol,double price, double change)
        {
            if (type.Name == "StockMarket")
            {
                Name = name;
                Symbol = symbol;
                Price = price;
                Change = change;
            }
           
        }
        private string Name { get; set;  }
        private string Symbol { get;  set; }
        private double Price { get; set; }
        private double Change { get; set; }
        ///...
    }
