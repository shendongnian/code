    public class MyModel : INotifyPropertyChanged
        {
            private int _MyProperty;
            public int MyProperty
            {
    
                get { return _MyProperty; }
                set
                {
                    if (value != _MyProperty)
                    {
                        _MyProperty = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
