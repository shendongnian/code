    public class Document : INotifyPropertyChanged
    {
        private string _accountNumber;
    
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (_accountNumber != value)
                {
                    _accountNumber = value;
                    //this tells the data binding system that the value has changed, so the interface should be updated
                    OnPropertyChanged("AccountNumber");
                }
            }
        }
    
        //raised whenever a property value on this object changes. The data binding system attaches to this event
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged:
    
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
