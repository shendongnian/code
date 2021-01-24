        private IEnumerable<Customer> _customers;
        public IEnumerable<Customer> Customers {
            get { 
                 if (_customers == null) 
                 {
                    _customers = _customerRepository.GetCustomers();
                 }
                 return _customers; 
            }
        }
    
       public AddCustomer(Customer customer) {
                 if (_customers == null) 
                 {
                    _customers = _customerRepository.GetCustomers();
                 }
                 _cusomers.Add(customer);   
       }
   
