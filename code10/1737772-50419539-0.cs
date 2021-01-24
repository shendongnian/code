    public class Customer { }
    public class CustomerData
    {
        public string MyProperty { get; private set; }
        private CustomerData()
        {
        }
        public Customer Customer { get; private set; }
        // or not void
        public static void Save(Customer customer)
        {
            // Check all datasources and save wherever you need to 
            // obviously through injection or whatever. I will just
            // new-it up here
            var cd = new CustomerData { Customer = customer };
            var repo1 = new CustomerRepository();
            repo1.Save(cd);
            bool someCondition = true;
            if (someCondition)
            {
                var repo2 = new CustomerRepository();
                repo2.Save(cd);
            }
        }
    }
