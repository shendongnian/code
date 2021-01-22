    public class CustomerSearchViewModel
    {
        public List<Customer> Customers { get; set; }
        // your search criteria if you want to include it
        public string SearchFirstName { get; set; }
        public string SearchLastName { get; set; }
        public int SearchCustomerID { get; set; }
        // etc...
    }
