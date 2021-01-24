        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                Button BTN_rect = new Button()
                {
                    Name = "rect" + i,
                    Content =Name,
                    Tag = i,
                    Background = Brushes.White,
                };
                BTN_rect.Click += BTN_rect_Click;
                sp.Children.Add(BTN_rect);
            }
        }
        private void BTN_rect_Click(object sender, RoutedEventArgs e)
        {
            Button current = sender as Button;
            current.Background = Brushes.Red;
            string targetName = $"rect{((int)current.Tag) + 1}";
            Button nextButton = sp.Children.OfType<Button>().Where(x => x.Name == targetName).SingleOrDefault();
            nextButton.Background = Brushes.Red;
        }
