    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FactorItem> FactorItems { get; set; }
    }
    public class FactorItem
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public bool IsBuy { get; set; }
        public Product Product { get; set; }
    }
