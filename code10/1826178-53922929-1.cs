    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FactorItem FactorItem { get; set; }
    }
    public class FactorItem
    {
        [Key, ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public bool IsBuy { get; set; }
        public Product Product { get; set; }
    }
