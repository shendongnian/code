    public class model
    {
        public decimal Price { get; set; }
        public decimal PriceWithTax
        {
            get
            {
                return Price * 1.125m;
            }
        }
    }
