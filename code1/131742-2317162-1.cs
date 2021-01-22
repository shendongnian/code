    public interface IPaymentType { }
    public class CreditCardPType : IPaymentType
    { }    
    public class Customer
    {
        public IPaymentType paymentType { get; set; }
    }
    Customer customer = new Customer();
    customer.paymentType = new CreditCardPType();
