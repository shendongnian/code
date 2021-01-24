        public class Header: INotifyPropertyChanged
        {
            private string _Value;
            public string Value
            {
                get
                {
                    return _Value;
                }
                set
                {
                    _Value = value;
                    OnPropertyChanged("Value");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
