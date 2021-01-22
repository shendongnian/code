    public class CustomerSearchEventArgs : EventArgs
    {
        public List<Customer> Customers { get; private set; }
        public CustomerSearchEventArgs(List<Customer> customers)
        {
            Customers = customers;
        }
    }
