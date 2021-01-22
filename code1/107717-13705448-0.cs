     public class Order
    {
        public Order()
        {
            _customerInitializer = new Lazy<Customer>(() => new Customer());
        }
        // other properties
        private Lazy<Customer> _customerInitializer;
        public Customer Customer
        {
            get
            {
                return _customerInitializer.Value;
            }
        }
        public string PrintLabel()
        {
            string result = Customer.CompanyName; // ok to access Customer
            return result + "\n" + _customerInitializer.Value.Address; // ok to access via .Value
        }
    }
