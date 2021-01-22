    void TabControl_SelectionChanged(object sender, RoutedEventArgs e)
    {
        TabControl tc = (TabControl) sender;
        if (tc.SelectedItem is ControlItem)
        {
            ItemsCollection ic = (ItemsCollection) tc.DataContext;
            tc.SelectedItem = ic.AddItem();
        }
    }
