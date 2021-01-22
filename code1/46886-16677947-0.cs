    ListViewItem item = new ListViewItem("Column1Text")
       { Tag = optionalRefToSourceObject };
    item.SubItems.Add("Column2Text");
    item.SubItems.Add("Column3Text");
    myListView.Items.Add(item);
