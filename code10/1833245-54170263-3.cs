    public class CustomersModel 
    {
        public int Amount { get; set; }
        public List<Customer> NewCustomers{ get; set; }
        CustomersModel()
        {
            Amount = new List<Customer>();
        }
    }
