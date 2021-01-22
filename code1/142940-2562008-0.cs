    public class MatchedCustomer : Customer
    {
        public MatchedCustomer(Customer customer)
        {
            // set properties from customer, i.e.
            FirstName = customer.FirstName;
        }
    }
