    public partial class MainWindow : Window
    {
        public string PlayerName
        {
            get { return (string)GetValue(Property); }
            set { SetValue(Property, value); }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayerName = user.Text;
        }
        public static readonly DependencyProperty Property =
            DependencyProperty.Register("PlayerName", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
