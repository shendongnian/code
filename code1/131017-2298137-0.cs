    public struct TradePrice 
    { 
        public decimal Price {get; private set;}
        public int Quantity {get; private set; }
        public TradePrice(decimal price, int quantity) : this()
        { 
            if (price < 0m) throw new ...
            if (quantity < 0) throw new ...
            this.Price = price; 
            this.Quantity = quantity; 
        } 
    } 
