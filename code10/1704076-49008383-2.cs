    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    
        public string OrderName { get; set; }
    
        public Nullable<DateTime> OrderDate { get; set; }
        public Customer Customer {get; set; }
    }
