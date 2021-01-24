        private Random _random;
        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var buttons = GetButtonsToChange();
            foreach (var button in buttons)
            {
                if (button != null)
                {
                    button.Background = CreateColor();
                }
            }
        }
        
        private Button[] GetButtonsToChange()
        {
            var amountOfButtons = RandBetween(0, 4);// <== 0 for none 4 because i only have 4 buttons
            var listOfIndexs = new List<ButtonNumbering>();
            var listOfButtons = new List<Button>();
            for (int i = 1; i <= amountOfButtons; i++)
            {
                var buttonItem = new ButtonNumbering(i,RandBetween(1,4));
                var alreadyHasButton = listOfIndexs.Select(x => x.Number).Contains(buttonItem.Number);
                if (alreadyHasButton)
                {
                    while (alreadyHasButton)
                    {
                        var newRandomNumber = RandBetween(1, 4);
                        buttonItem.Number = RandBetween();
                        alreadyHasButton = listOfIndexs.Select(x => x.Number).Contains(buttonItem.Number);
                    }
                }
                listOfIndexs.Add(buttonItem);
                var buttonName = $"Button{buttonItem.Number}";//<= the names of the buttons are Button1 Button2 Button3 Button4
                var button = (Button)FindName(buttonName);
                 listOfButtons.Add(button);
            }
            return listOfButtons.ToArray();
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
