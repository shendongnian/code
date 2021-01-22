    public class CustomerCollection: Collection<Customer>
    {
      public CustomerCollection: : base(new List<Customer>())
       {}
    
      public static IList<Customer> FindCustomers()
      {
       //return them from DAL
      }
    }
