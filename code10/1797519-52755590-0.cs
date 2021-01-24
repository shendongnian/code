        private void ButtonCreateNewButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = new Button();
            b.Height = 30;
            b.Width = 100;
            b.VerticalAlignment = VerticalAlignment.Top;
            b.HorizontalAlignment = HorizontalAlignment.Left;
            b.Margin = new Thickness(6, 6, 6, 6);
            b.Content = "Button " + buttonCounter;
            b.Tag = "LED-" + buttonCounter;
            b.Click += Button_Click;
            ....
            buttonCounter++;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var led = btn.Tag;
            //use led_name as a parameter here, according with this variable to turn on the LED
            TurnOnOffLed(led);
        }
