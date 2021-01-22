    private void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ListViewItem item = sender as ListViewItem;
        object obj = item.Content;
    }
