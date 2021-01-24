        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_TextChanged(object sender, TextChangedEventArgs e)
        {
            OutputLabel.Content = $"Happy {((TextBox)e.OriginalSource).Text}";
        }
    }
