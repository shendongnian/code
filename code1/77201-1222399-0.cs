    public static class Customers
    {
    
      public static Collection<Customer> FindCustomers()
       {
         //calls DAL and gets a Collection of customers
         Collection<Customer> customers = DAL.GetCustomers();
    
         return customers;
       }
    }
