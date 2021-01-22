       set
        {
            if (value != _customer.FirstName)
           {
  
               _customer.FirstName = value;
              base.OnPropertyChanged("FirstName");
           }
        }
