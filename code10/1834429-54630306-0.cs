    public class CsvData
    {
        public string Enabled { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
    public class CsvDataBuilder
    {
        public bool Enabled { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } 
        public CsvData ToCsvData()
        {
            return new CsvData
            {
                Enabled = Enabled.ToString(),
                Quantity = Quantity.ToString(),
                Price = Price.ToString()
            };
        }
    }
