        public class MainViewModel : INotifyPropertyChanged
        {
            public MainViewModel()
            {
                Packages = new List<PackageModel>()
                {
                    new PackageModel()
                    {
                        Id = 1, SessionName="Session1", IsActive = true
                    },
                    new PackageModel()
                    {
                        Id = 2, SessionName="Session2", IsActive = false
                    }
                };
            }
    
            private PackageModel _SelectedPackage;
            public PackageModel SelectedPackage
            {
                get { return _SelectedPackage; }
                set
                {
                    if (value != _SelectedPackage)
                    {
                        _SelectedPackage = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            private List<PackageModel> _Packages;
            public List<PackageModel> Packages
            {
                get { return _Packages; }
                set
                {
                    if (value != _Packages)
                    {
                        _Packages = value;
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
