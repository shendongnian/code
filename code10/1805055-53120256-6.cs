    public class OrderProduct
    {
        [CsvColumn(FieldIndex = 0)]
        public string Product { get; set; }
        [CsvColumn(FieldIndex = 1)]
        public string Price { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public string OrderQuantity { get; set; }
        public string Value { get; set; }
        public string calculateValue()
        {
            return (Convert.ToDouble(Price) * Convert.ToDouble(OrderQuantity)).ToString();
        }
    }
