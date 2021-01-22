     public MainWindow()
     {
         InitializeComponent();
         DataContext = new MainViewModel(GetAllEmployees());
     }
