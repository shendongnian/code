        public MainWindow()
        {
            this.InitializeComponent();
        }
        public static readonly DependencyProperty BlockerZIndexProperty =
            DependencyProperty.Register(
                nameof(BlockerZIndex),
                typeof(int),
                typeof(MainWindow),
                new PropertyMetadata(2));
        public int BlockerZIndex
        {
            get => (int) GetValue(BlockerZIndexProperty);
            set => SetValue(BlockerZIndexProperty, value);
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            BlockerZIndex = BlockerZIndex == 1 ? 2 : 1;
        }
