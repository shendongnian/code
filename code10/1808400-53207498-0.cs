    public class Customer
    {
        public int Id { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
    
    public class Payment
    {
        public int PaymentId{ get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
