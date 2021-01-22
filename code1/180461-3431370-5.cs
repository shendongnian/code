    interface IPaymentVisitor {
    }
    interface IPaymentVisitor<TPayment> : IPaymentVisitor where TPayment : Payment {
      void Visit(TPayment payment);
    }
    abstract class Payment {
      public abstract void Accept(IPaymentVisitor visitor);
    }
    class CreditCard : Payment {
      public override void Accept(IPaymentVisitor visitor) {
        if (visitor is IPaymentVisitor<CreditCard>) {
          ((IPaymentVisitor<CreditCard>)visitor).Visit(this);
        }
      }
    }
    class StoredCredit : Payment {
      public override void Accept(IPaymentVisitor visitor) {
        if (visitor is IPaymentVisitor<StoredCredit>) {
          ((IPaymentVisitor<StoredCredit>)visitor).Visit(this);
        }
      }
    }
    class CreditCardPaymentTaker : IPaymentVisitor<CreditCard>, IPaymentTaker {
      public void Visit(CreditCard payment) {
        // ...
      }
      public PaymentProcessingResult Process(Payment payment) {
        payment.Accept(this);
        // ...
      }
    }
    class StoredCreditPaymentTaker : IPaymentVisitor<StoredCredit>, IPaymentTaker {
      public void Visit(StoredCredit payment) {
        // ...
      }
      public PaymentProcessingResult Process(Payment payment) {
        payment.Accept(this);
        // ...
      }
    }
