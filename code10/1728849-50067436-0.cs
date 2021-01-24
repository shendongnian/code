        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button1.Background = CreateColor();
            Button2.Background = CreateColor();
            Button3.Background = CreateColor();
            Button4.Background = CreateColor();
        }
        private SolidColorBrush CreateColor()
        {
            return new SolidColorBrush(Color.FromRgb(RandomInt(),RandomInt(),RandomInt()));
        }
        private byte RandomInt()
        {
            var random = new Random();
            var randomNumber = Convert.ToByte(random.Next(0, 255));
            return randomNumber;
        }
