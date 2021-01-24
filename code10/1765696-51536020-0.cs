     public class  MyCommand : INotifyPropertyChanged
        {
            private string _dispalyName ;
            public string DispalyName 
            {
                get { return _dispalyName ; }
                set
                {
                    _dispalyName = value;
                    NotifyOfPropertyChange("DispalyName");
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyOfPropertyChange(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
    
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
