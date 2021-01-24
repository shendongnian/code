    public partial class MainWindow : Window
    {
        public List<Fruits> FruitList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FruitList = new List<Fruits>()
            {
                new Fruits("Apple", Colors.Red),
                new Fruits("Pear", Colors.Green),
                new Fruits("Grape", Colors.Purple)
            };
            cboColors.ItemsSource = FruitList;
        }
    }
