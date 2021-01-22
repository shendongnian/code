        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomerIndex;
            }
            set
            {
                _selectedCustomer = value;
                _selectedCustomerIndex = _customers.IndexOf(value);
                OnPropertyChanged("SelectedCustomer");
                OnPropertyChanged("SelectedCustomerIndex");
            }
        }
        public int SelectedCustomerIndex
        {
            get
            {
                return _selectedCustomerIndex;
            }
            set
            {
                _selectedCustomerIndex = value;
                _selectedCustomer = _customers[_selectedCustomerIndex];
                OnPropertyChanged("SelectedCustomer");
                OnPropertyChanged("SelectedCustomerIndex");
            }
        }
