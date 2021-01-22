    public class MyClass : Window
    {
        public MyClass()
        {
            Loaded += MyLoadedRoutedEventHandler;
        }
        void MyLoadedRoutedEventHandler(Object sender, RoutedEventArgs e)
        {
            Loaded -= MyLoadedRoutedEventHandler;
            /// ...
        }
    };
