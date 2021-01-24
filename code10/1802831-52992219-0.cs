    private void Details_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (IsLoaded)
        {
            TabItem tabItem = e.AddedItems[0] as TabItem;
            TabControl tabControl = sender as TabControl;
            tb.Text = "Selected" + tabItem.Name + " in control " + tabControl.Name;
            e.Handled = true;
        }
    }
