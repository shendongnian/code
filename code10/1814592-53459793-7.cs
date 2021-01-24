    public class MainWindow : Window {
        [Dependency]
        public MainWindowViewModel ViewModel {
            set { DataContext = value; }
        }
     
        public MainWindow() {
            InitializeComponent();
            Loaded += OnLoaded;
        }
        
        void OnLoaded(object sender, EventArgs args) {
            FrameContent.Navigate(new PageConsignments());
        }
    }
    
