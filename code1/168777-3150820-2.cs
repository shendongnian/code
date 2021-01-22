     /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<MyBool> Users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<MyBool>();
            DataContext = this;
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
              
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillUsers();
        }
        private void FillUsers()
        {
            for (int i = 0; i < 20; i++)
            {
                if(i%2 == 0)
                    Users.Add(new MyBool { Value = true });
                else
                    Users.Add(new MyBool {  Value = false});
            }
        }
    }
