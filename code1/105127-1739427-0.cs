    class MyClass
    {
        // Can be called on any thread
        public ReceiveLibraryEvent(RoutedEventArgs e)
        {
            if (Application.Current.CheckAccess())
            {
                this.ReceiveLibraryEventInternal(e);
            }
            else
            {
                Application.Current.Dispatcher.Invoke(
                    new Action<RoutedEventArgs>(this.ReceiveLibraryEventInternal));
            }
        }
    
        // Must be called on the UI thread
        private ReceiveLibraryEventInternal(RoutedEventArgs e)
        {
             // Handle event
        }
    }
