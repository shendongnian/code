    public int SelectedCustomerIndex
    {
        get
        {
            return _selectedCustomerIndex;
        }
    
        set
        {
            if (value != _selectedCustomerIndex)
            {
             _selectedCustomerIndex = value;
             OnPropertyChanged("SelectedCustomerIndex");
             SelectedCustomer = _customers[_selectedCustomerIndex];
            }
        }
    }
