    private static Dictionary<ListViewItem, MyClass> ListViewItemLookup = 
       new Dictionary<ListViewItem, MyClass>();
    public ListViewItem GetListViewItem()
    {
       ListViewItem item = new ListViewItem();
       item.Text = SomeProperty;
       // population of other ListViewItem columns goes here
       ListViewItemLookup.Add(item, this);
       return item;
    }
