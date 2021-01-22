    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
            foreach (var item in e.AddedItems.OfType<ListViewItem>())
            {
                    Clipboard.SetText(item.ToString());
            }
    }
