    public static class AppCommands
    {
        public static RoutedCommand SendData { get { return _sendDataCommand; } }
    
        private static RoutedCommand _sendDataCommand = new RoutedCommand
        (
            "Send Data",
            typeof(AppCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.N, ModifierKeys.Alt)
            }
        )
    }
