    public class EventBuilder
    {
        private static RoutedEventHandler _buttonClickHandler;
    
        public EventBuilder(RoutedEventHandler buttonClickHandler)
        {
            _buttonClickHandler = buttonClickHandler;
        }
    
        public static void EnableClickEvent()
        {
            myButton.Click += new RoutedEventHandler(_buttonClickHandler);
        }
    }
