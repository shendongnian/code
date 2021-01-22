    public class CustomerWithGroups
    {
        public CustomerWithGroups(Customer c) { Customer = c; }
        public Customer Customer { get; private set; }
        public string GroupName { get; set; }
        public string Fullname
        {
            get
            {
                return string.Format("{0} {1} {2}", Customer.firstname, Customer.middlename, Customer.lastname).Replace("  ", " ");
            }
        }
    }
