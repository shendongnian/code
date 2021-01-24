    private static void EnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        Menu menu = (Menu)d;
        if ((bool)e.NewValue)
        {
            menu.AddHandler(MenuItem.SubmenuOpenedEvent, (RoutedEventHandler)Menu_Opened);
        }
        else
        {
            menu.RemoveHandler(MenuItem.SubmenuOpenedEvent, (RoutedEventHandler)Menu_Opened);
        }
    }
