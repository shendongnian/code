    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (string item in e.RemovedItems)
        {
            SelectedItems.Remove(item);
        }
        foreach (string item in e.AddedItems)
        {
            SelectedItems.Add(item);
        }
    }
