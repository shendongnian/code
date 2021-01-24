        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowPage_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Type pageType = btn.Tag as Type;
            var pg = Activator.CreateInstance( pageType);
            TheFrame.Content = pg;
        }
