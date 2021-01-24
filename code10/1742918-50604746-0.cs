    private class WindowHelper
    {
        // Third parameter is a Menu, not a MenuItem
        public static void Enable(HwndSource hwndSource, Window window, Menu menu)
        {
            WindowHelper helper = new WindowHelper(hwndSource, window);
            hwndSource.AddHook(helper.WndProc);
            
            // Subscribe to the routed event MenuItem.SubmenuClosed
            menu.AddHandler(MenuItem.SubmenuClosedEvent, (RoutedEventHandler)helper.Menu_Closed);
        }
        // The method signature has to be changed - this is a routed event handler now
        private void Menu_Closed(object sender, RoutedEventArgs e)
        {
            Menu menu = (Menu)sender;
            MenuItem menuItem = (MenuItem)e.Source;
            if (menuItem.Parent != menu)
            {
                // If it's not the first level menu, ignore it.
                // We only disable our helper when the whole menu closes.
                return;
            }
            // Unsubscribe from the routed event
            menu.RemoveHandler(MenuItem.SubmenuClosedEvent, (RoutedEventHandler)Menu_Closed);
            mHwndSource.RemoveHook(WndProc);
        }
        // Rest is unchanged
        // ...
    }
