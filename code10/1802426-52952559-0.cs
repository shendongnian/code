    public partial class Window1 : Window
    {
        private readonly MainWindow _mainWindow;
        public Window1(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = _mainWindow.textBox1.Text;
            label2.Content = _mainWindow.textBox2.Text;
        }
    }
