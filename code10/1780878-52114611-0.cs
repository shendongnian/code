    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string _Route;
        public string Route
        {
            get { return _Route; }
            set { _Route = value; OnPropertyChanged("Route"); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public MainWindowViewModel(){}
    }
