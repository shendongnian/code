    class Order : BaseModel
    {
        public int Id { get; set; }
        // every Order has zero or more OrderLines
        public virtual ICollection <OrderLines> OrderLines { get; set; }
        public double? Total { get; set; }
    }
    public class OrderLines : BaseModel
    {
        public int id { get; set; }
        // every OrderLine belongs to exactly one Order, using foreign key
        public int OrderId {get; set;}
        public virtual Order Order { get; set; }
        public int? Ordernum { get; set; }
        [MaxLength(1000)]
        public string Sku { get; set; }
    }
