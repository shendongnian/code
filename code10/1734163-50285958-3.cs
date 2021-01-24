     public MainWindow()
            {
                InitializeComponent();
    
                BaseViewModel.RegisterAssemblyAndBase(typeof(MainWindow).Assembly, typeof(BaseViewModel));    
               
            }
