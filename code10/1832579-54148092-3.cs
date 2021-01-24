    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            myGrid.DataContext = this;
            _name2 = "Start...";
            Loaded += MainWindow_Loaded;
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //wait for 2 seconds...
            await Task.Delay(2000);
            //...and then set the property
            Name2 = "new...";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _name2;
        public string Name2
        {
            get { return _name2; }
            set
            {
                if (value != _name2)
                {
                    _name2 = value;
                    OnPropertyChanged("Name2");
                }
            }
        }
    }
