    public partial class MainWindow : Window
    {
        public bool Checked { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            cb1.DataContext = this;
        }
        private void myyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Checked.ToString());
        }
    }
