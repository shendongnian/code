    private static void Menu_Opened(object sender, RoutedEventArgs e)
    {           
        Menu menu = (Menu)sender;
        MenuItem menuItem = (MenuItem)e.Source;
        if (menuItem.Parent != menu)
        {
            // We don't want to process any sub-menus in the deeper levels,
            // because the helper will already be enabled when
            // a first level menu opens
            return;
        }
        Window w = Window.GetWindow(menu);
        if (w != null)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(w).Handle);
            if (source != null)
            {
                WindowHelper.Enable(source, w, menu);
            }
        }
    }
