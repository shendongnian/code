        protected override void OnStartup(StartupEventArgs e)
        {
            //works for tab into textbox
            EventManager.RegisterClassHandler(typeof(TextBox),
                TextBox.GotFocusEvent,
                new RoutedEventHandler(TextBox_GotFocus));
            //works for click textbox
            EventManager.RegisterClassHandler(typeof(Window),
                Window.GotMouseCaptureEvent,
                new RoutedEventHandler(Window_MouseCapture));
    
            base.OnStartup(e);
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        private void Window_MouseCapture(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)
                 textBox.SelectAll(); 
        }
