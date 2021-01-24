        private Random _random;
        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button1.Background = CreateColor();
            Button2.Background = CreateColor();
            Button3.Background = CreateColor();
            Button4.Background = CreateColor();
        }
        private SolidColorBrush CreateColor()
        {
            var red = RandBetween();
            var green = RandBetween();
            var blue = RandBetween();
            return new SolidColorBrush(Color.FromRgb(red,green,blue));
        }
        private byte RandBetween(int bottom=0, int top=255)
        {
            var randomNumber = Convert.ToByte(_random.Next(bottom, top));
            return randomNumber;
        }
