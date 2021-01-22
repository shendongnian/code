    public class Person : INotifyPropertyChanged
        {
            private int _id;
            private string _name;
            private string _lastName;
    
            public int Id
            {
                get { return _id; }
                set
                {
                    if (value != _id)
                    {
                        _id = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged();
                    }
                }
            }
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (value != _lastName)
                    {
                        _lastName= value;
                        OnPropertyChanged();
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
        }
