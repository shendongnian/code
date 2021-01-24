    class Customer
    {
        public string CustomerName { get; set; }
        public CheckingAccount Account { get; set; }
        public Customer(string customerName, CheckingAccount account)
        {
            CustomerName = customerName;
            Account = account;
        }
    }
