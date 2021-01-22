    public interface IPaymentType 
    {
      bool Pay(double amount);
    }
    public class CreditCardPType : IPaymentType
    {
      double limit;
      // implement Pay()
    }    
    public class Cheque: IPaymentType
    {
      int accountNumber;
      // implement Pay()
    } 
    public class Customer
    {
        public IPaymentType paymentType { get; set; }
    }
    Customer customer = new Customer();
    customer.paymentType = new CreditCardPType();
