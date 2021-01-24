    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel
            {
                Items =
                {
                    // these are samle items;
                    // you can fill collection the way you want
                    new ItemViewModel { Name1 = "A", Name2 = "B" },
                    new ItemViewModel { Name1 = "C", Name2 = "D" },
                    new ItemViewModel { Name1 = "E", Name2 = "F" },
                }
            };
        }
    }
