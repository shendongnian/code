    public class FakeCustomerRepository
    {
      private IList<Customer> m_Customers = new List<Customer>()
                   {
                      [insert SQL text transform here]
                   };
    
      public Customer Get(...)
      {
        return m_Customers.Find(...);
      }
    }
