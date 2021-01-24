    class MainWindow : Window
    {
        public ViewModelClass Viewmodel { get; private set; }
        public MainWindow(ViewModelClass viewmodel)
        {
            this.Viewmodel = viewmodel;
            InitializeComponent();
        }
    }
    
