    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderTime { get; set; }
        public double Total { get; set; }   
        public virtual ICollection<Product> Cart { get; } = new HashSet<Product>();
    }
