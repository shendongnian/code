    public partial class MainWindow : Window
    {
        static MainWindow()
        {
          // only for demonstration!!!
          Bootstrapper.Initialize();
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Container container = Bootstrapper.MyContainer;
    
            UserManagement instance = container.GetInstance<UserManagement>();
            MessageBox.Show(instance.Test);
        }
    }
