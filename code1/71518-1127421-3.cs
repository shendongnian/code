    ListView l = (ListView)sender;
    if (l.SelectedItem != null)
    {
        MyClassListViewItem item = l.SelectedItem as MyClassListViewItem;
        if (item != null)
        {
           item.MyClass.Method();
        }
    }
