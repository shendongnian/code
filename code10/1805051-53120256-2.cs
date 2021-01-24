    public class OrderProduct
    {
        [CsvColumn(Name = "product")]
        public string Product { get; set; }
        [CsvColumn(Name = "price")]
        public string Price { get; set; }
        [CsvColumn(Name = "orderQty")]
        public string OrderQuantity { get; set; }
        public string Value { get; set; }
        public string calculateValue()
        {
            return (Convert.ToDouble(Price) * Convert.ToDouble(OrderQuantity)).ToString();
        }
    }
