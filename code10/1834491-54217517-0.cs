    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            GetData();
        }
        private List<Country> _countries;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<Country> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged();
            }
        }
        private void GetData()
        {
            // call database here
            var countries = new List<Country>()
            {
                new Country() {Name = "Usa"},
                new Country() {Name = "Mexico"},
            };
            Countries = countries;
        }
    }public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            GetData();
        }
        private List<Country> _countries;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<Country> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged();
            }
        }
        private void GetData()
        {
            // call database here
            var countries = new List<Country>()
            {
                new Country() {Name = "Usa"},
                new Country() {Name = "Mexico"},
            };
            Countries = countries;
        }
    }
