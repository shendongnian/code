    public class PackageModel : INotifyPropertyChanged
        {
            private int _Id;
            public int Id
            {
                get { return _Id; }
                set
                {
                    if (value != _Id)
                    {
                        _Id = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            private string _SessionName;
            public string SessionName
            {
                get { return _SessionName; }
                set
                {
                    if (value != _SessionName)
                    {
                        _SessionName = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            private bool _IsActive;
            public bool IsActive
            {
                get { return _IsActive; }
                set
                {
                    if (value != _IsActive)
                    {
                        _IsActive = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
