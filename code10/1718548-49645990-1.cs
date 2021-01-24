    List<string> ls = new List<string>();
    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.AddedItems)
        {
            ls.Add((item as ListViewItem).Content.ToString());
        }
        foreach (var _item in e.RemovedItems)
        {
            ls.Remove((_item as ListViewItem).Content.ToString());
        }  
    }
    
