    TreeViewItem root_item = new TreeViewItem() { Header = "Users" };
    treeView.Items.Add(root_item);
    while (sqlReader.Read()) 
    {
        var new_item = new TreeViewItem { Header = sqlReader.GetString(0), Tag = true };
        new_item.HeaderTemplate = Resources["headerTemplate"] as DataTemplate;
        root_item.Items.Add(new_item);
    }
