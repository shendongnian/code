    public class Order
    {
        public Guid Id { get; set; }
        public PaymentContainer PaymentContainer { get; set; }
    }
    public class PaymentContainer
    {
        public string Type { get; set; }
        public PaymentParameters PaymentParameters { get; set; }
    }
    public class PaymentParameters
    {
        public string Name { get; set; }
        public string Provider { get; set; }
    }
