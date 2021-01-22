    class Product {
        public String PartNo { get; set; }
        public String Description { get; set; }
        public Decimal BasePrice { get; set; }
        public Dictionary<String, Decimal> ForeignPrices;
    }
