    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListView listView = sender as ListView;
        if (listView.SelectedItems.Count == 0)
            foreach (object item in e.RemovedItems)
                listView.SelectedItems.Add(item);
    }
