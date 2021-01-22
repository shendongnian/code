    public class Customercollection: Collection<Customer>
    {
    }
    
    public class Customer
    {
        public static CustomerCollection FindCustomers()
        {
            return DAL.GetCustomers();
        }
    }
