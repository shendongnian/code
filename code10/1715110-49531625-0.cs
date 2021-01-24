    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private Type _nextPage;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public Type NextPage
        {
            get
            {
                return _nextPage;
            }
            set
            {
                _nextPage = value;
                OnPropertyChanged();
            }
        }
    
        public MainPageViewModel()
        {
             _nextPage = typeof(HomePage);
        }
    }
