    public class YourViewModel
    {
        public ObservableCollection<Customer> CustomersList = new ObservableCollection<Customer> { get; set; }
        
        public void UpdateCustomers(IEnumerable<Customers> newCustomers)
        {
            CustomersList.Clear();
            foreach (var customer in newCustomers)
                CustomersList.Add(customer);
        }
    }
