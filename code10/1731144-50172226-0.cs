    await  Task.Delay(500);
    foreach (NavigationViewItemBase item in navView.MenuItems)
    {
        if (item is NavigationViewItem && item.Tag.ToString() == "home")
        {
        
            navView.SelectedItem = item;
            (navView.SelectedItem as NavigationViewItem).IsSelected = true;
            break;
        }
    }
