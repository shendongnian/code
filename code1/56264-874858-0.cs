    public class CustomerViewModel : INotifyPropertyChanged
    {
            readonly Customer _customer;
            public CustomerViewModel(Customer customer)
            {
                _customer = customer;
            }
    
            public string FirstName
            {
                get { return _customer.FirstName; }
                set
                {
                    if (value == _customer.FirstName)
                        return;
    
                    _customer.FirstName = value;
    
                    OnPropertyChanged("FirstName");
                }
            }
            ...
    }
