        public partial class MainWindow : Window
        {
            public MainWindow()
                 {
                    InitializeComponent();
                    Loaded += MainWindow_Loaded;
                 }
        
                private void MainWindow_Loaded(object sender, RoutedEventArgs e)
                {
                    // For test: LOAD & SET your DataContext here
                    //
                    var myDogViewmodel = new DogViewModel();
                    myDogViewModel.LoadData();
                    this.DataContext = myDogViewmodel;
                }
            }
    
    
