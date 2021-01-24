    private IEnumerable<Customer> _customers;
    public IEnumerable<Customer> Customers {
        get { 
             if (_customers == null) 
             {
                _customers = _customerRepository.GetCustomers();
             }
             return _customers; 
        }
        set { _customer = value; }
    }
