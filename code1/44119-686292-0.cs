    public interface IPaymentService
    {
      Guid PopulateTable();
      Order GetOrder(Guid id);
    }
    
    public class PayPalPaymentService : IPaymentService
    {
      public Guid PopulateTable() { ... }
      public Order GetOrder(Guid id) { ... }
    }
    
    public class GooglePaymentService : IPaymentService
    {
      public Guid PopulateTable() { ... }
      public Order GetOrder(Guid id) { ... }
    }
