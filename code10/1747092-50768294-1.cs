    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<int> FontSizes { get; set; }
        private int _selectedFont;
        public int SelectedFont
        {
            get { return _selectedFont; }
            set
            {
                _selectedFont = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFont)));
            }
        }
        public MainViewModel()
        {
            FontSizes = new ObservableCollection<int>() { 10, 15, 20 };
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
