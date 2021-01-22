    class MyWindow : Window
    {
        Button _button;
        
        public MyWindow()
        {
            _button = new Button();
            // place the button in the window
            _button.Click += MyWindow.ButtonClicked;
        }
    
        static void ButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked");
        }
    }
