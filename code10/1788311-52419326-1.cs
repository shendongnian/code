    public sealed partial class MainPage : Page,INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.ActualThemeChanged += MainPage_ActualThemeChanged;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void MainPage_ActualThemeChanged(FrameworkElement sender, object args)
        {
            IsError = !IsError;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = this.RequestedTheme == ElementTheme.Light ? ElementTheme.Dark : ElementTheme.Light;
        }
    
        private void OnPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
    
        private bool? isError=true;
        public bool? IsError
        {
            get
            {
                return isError;
            }
            set
            {
                isError = value;
                OnPropertyChanged("IsError");
            }
        }
    
    }
