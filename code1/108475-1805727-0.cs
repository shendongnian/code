    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set the View's DataContext to be an instance of the class that contains your CollectionView...
            this.DataContext = new MainWindowViewModel();
        }
    }
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
        }
        public object ModelItem { get; set; }
    }
    public class ModelItem
    {
        public CollectionView DataTypesDisplayed { get; set; }
    }
