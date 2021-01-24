    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var foo = new FooClass();
            foo.Raw = new ObservableCollection<string>(new List<string> { "1", "2", "3" });
            DataContext = foo;
        }
    }
