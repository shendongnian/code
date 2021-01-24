    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            numberGrid.ItemsSource = Enumerable.Range(1, 100);
            numberGrid.ScrollIntoView(numberGrid.Items[numberGrid.Items.Count - 1]);
        }
        int n = 0;
        private void DataGridRow_Loaded(object sender, RoutedEventArgs e)
        {
            txt.Text = (n++).ToString();
        }
    }
