    private void navView_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (NavigationViewItemBase item in navView.MenuItems)
        {
            if (item is NavigationViewItem && item.Tag.ToString() == "home")
            {
    
                navView.SelectedItem = item;
                (navView.SelectedItem as NavigationViewItem).IsSelected = true;
                break;
            }
        }
    }
    private void navView_Loading(FrameworkElement sender, object args)
    {
        navView.MenuItems.Add(new NavigationViewItem()
        { Content = "Home", Icon = new SymbolIcon(Symbol.Home), Tag = "home" });
    
        navView.MenuItems.Add(new NavigationViewItem()
        { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });
    
        navView.MenuItems.Add(new NavigationViewItem()
        { Content = "Mail", Icon = new SymbolIcon(Symbol.Mail), Tag = "mail" });
    }
