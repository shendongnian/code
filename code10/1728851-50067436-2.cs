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
            Button3.Background = CreateColor(10,40);
            Button4.Background = CreateColor(10,40);
        }
        private SolidColorBrush CreateColor(int bottom=0, int top=255)
        {
            var red = RandBetween(bottom,top);
            var green = RandBetween(bottom,top);
            var blue = RandBetween(bottom,top);
            return new SolidColorBrush(Color.FromRgb(red,green,blue));
        }
        private byte RandBetween(int bottom=0, int top=255)
        {
            var randomNumber = Convert.ToByte(_random.Next(bottom, top));
            return randomNumber;
        }
