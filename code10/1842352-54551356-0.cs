public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonConnection(object sender, RoutedEventArgs e)
        {
            var myObj = new Class1();
            myObj.displayTest();
        }
    }
