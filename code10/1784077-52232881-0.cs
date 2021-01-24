    public class CustList:INotifyPropertyChanged
        {
            //i want to display/bind this in Listview
            private List<CustomerOrder> _CUSTOMER_ORDER
            public List<CustomerOrder> CUSTOMER_ORDER 
            { 
              get{return _CUSTOMER_ORDER;}
              set{
                  _CUSTOMER_ORDER=value;
                  OnPropertyChanged("CUSTOMER_ORDER");
                 } 
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(propertyName));
            }
        }
