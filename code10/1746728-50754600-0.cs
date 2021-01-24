    public interface ICustomerAccountInformation {  }
    public interface IPaymentClient {  }  // Identifies whom the payment is intended for
    public interface ITransactionDetails : IPaymentClient {  }  // Identifies amount, beneficiary details to be reflected in customer account
    public interface IPaymentStatus { }
    
    public interface IPaymentProvider  { 
        IPaymentStatus ProcessPayment(ICustomerAccountInformation customerInfo, ITransactionDetails transaction);
    }
    public class PayPal : IPaymentProvider  {
        public IPaymentStatus ProcessPayment(ICustomerAccountInformation customerInfo, ITransactionDetails transaction)  {
               /* Open paypal's login page, 
                 do its own checks and process payment. 
                 Once successfull, send back to referrer with the payment status
               */
        }
    public class NetbankingProvider : IPaymentProvider  {
        public IPaymentStatus ProcessPayment(ICustomerAccountInformation customerInfo, ITransactionDetails transaction)  {
               /* Redirect to bank selection
                 redirect to bank's login page, 
                 do its own checks and process payment. 
                 Once successfull, send back to referrer with the payment status
               */
        }
