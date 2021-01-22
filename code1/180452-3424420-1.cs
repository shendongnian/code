    public class Payment
    {
    }
    public class CreditCardPayment : Payment
    {
    }
    public class StoreCreditPayment : Payment
    {
    }
    public interface IPaymentTaker
    {
    }
    public interface IPaymentTaker<T> : IPaymentTaker
    {
        void Process(T payment);
    }
    public static class PaymentTaker
    {
        public static void Process(Payment payment)
        {
            var paymentType = payment.GetType();
            // You would have these already setup and loaded via your IOC container...
            var paymentTakers = new Dictionary<Type, IPaymentTaker>();
            paymentTakers.Add(typeof(CreditCardPayment), new CreditCardPaymentTaker());
            paymentTakers.Add(typeof(StoreCreditPayment), new StoreCreditPaymentTaker());
            // Get the payment taker for the specific payment type.
            var paymentTaker = paymentTakers[paymentType];
                
            // Execute the 'Process' method.
            paymentTaker.GetType().GetMethod("Process").Invoke(paymentTaker, new object[]{ payment });
        }
    }
    public class CreditCardPaymentTaker : IPaymentTaker<CreditCardPayment>
    {
        public void Process(CreditCardPayment payment)
        {
            Console.WriteLine("Process Credit Card Payment...");
        }
    }
    public class StoreCreditPaymentTaker : IPaymentTaker<StoreCreditPayment>
    {
        public void Process(StoreCreditPayment payment)
        {
            Console.WriteLine("Process Credit Card Payment...");
        }
    }
