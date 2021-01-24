    private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
       var sel = e.Source as TreeViewItem;
       if(sel != null)
       {
          String text = sel.Header as String;
       }
    }
