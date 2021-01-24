    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CurrentTimeViewModel();
        }
    }
    public class CurrentTimeViewModel : INotifyPropertyChanged
    {
        private string _currentTime;
        public CurrentTimeViewModel()
        {
            UpdateTime();
        }
        private async void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToString("G");
            await Task.Delay(1000);
            UpdateTime();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value; OnPropertyChanged(); }
        }
    }
