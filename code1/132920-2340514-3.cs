    private static void MoveSelectedItems(ListView source, ListView target)
    {    
        while (source.SelectedItems.Count > 0)
        {
            ListViewItem temp = source.SelectedItems[0];
            source.Items.Remove(temp);
            target.Items.Add(temp);
        }            
    }
