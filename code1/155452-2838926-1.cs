    var items = treeView1.Items;
    var item = new TreeViewItem() { Header = "Interesting" };
    items.Add(item);
    var subitem = new TreeViewItem() {Header = "Sub Item"};
    foreach (TreeViewItem n in items)
    {
      if (n.Header == "Interesting")
        (n as TreeViewItem).Items.Add(subitem);
    }
