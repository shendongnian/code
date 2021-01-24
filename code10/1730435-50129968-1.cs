        public MainWindow()
        {
            InitializeComponent();
            lbCheque.ItemsSource = new List<string> {"aa","bb","cc" };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbCheque.SelectedItem = "bb";
        }
