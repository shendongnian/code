     public MainWindow()
        {
            InitializeComponent();           
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ViewModel();
        }
