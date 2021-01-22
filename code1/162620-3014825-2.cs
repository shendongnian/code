    class PaymentService {
    
      IEnumerable<IAccount> accounts;
      
      public PaymentService (IUnityContainer container) {
        this.accounts = container.ResolveAll<IAccount>();
      }
    
      public void ProcessPayment() {
        foreach(var account in accounts) {
          account.Chackbalance();
        }
      }
    }
    //Registration is pretty clean in this case
    container.RegisterType<IAccount, CreditCardAccount>();
    container.RegisterType<PaymentService>();
    container.RegisterInstance<IUnityContainer>(container);
