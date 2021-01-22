        public static readonly RoutedEvent NewItemAddedEvent =
            EventManager.RegisterRoutedEvent("NewItemAdded", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(CloseableTabItem));
        public event RoutedEventHandler NewItemAdded
        {
            add { AddHandler(NewItemAddedEvent, value); }
            remove { RemoveHandler(NewItemAddedEvent, value); }
        }
