     public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        [CurrencyScrubber]
        public decimal Price { get; set; }
    }
