    public class Product
    {
        public Price CurrentPrice {get; private set; }
        public IList<Price> HistoricPrices { get; private set;}
    }
    
    public class Price { }
