    interface IPaymentVisitor {
      void Visit(CreditCard payment);
      void Visit(StoredCredit payment);
    }
    abstract class Payment {
      public abstract void Accept(IPaymentVisitor visitor);
    }
    class CreditCard : Payment {
      public override void Accept(IPaymentVisitor visitor) {
        visitor.Visit(this);
      }
    }
    class StoredCredit : Payment {
      public override void Accept(IPaymentVisitor visitor) {
        visitor.Visit(this);
      }
    }
    class PaymentTaker : IPaymentVisitor, IPaymentTaker {
      public void Visit(CreditCard payment) {
        // ... 
      }
      public void Visit(StoredCredit payment) {
        // ... 
      }
      public PaymentProcessingResult Process(Payment payment) {
        payment.Accept(this);
        // ...
      }
    }
