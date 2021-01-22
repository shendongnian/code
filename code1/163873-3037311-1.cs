    public delegate void AddListViewItemCallBack(ListView control, ListViewItem item);
    public static void AddListViewItem(ListView control, ListViewItem item)
    {
        if (control.InvokeRequired)
        {
            AddListViewItemCallBack d = new AddListViewItemCallBack(AddListViewItem);
            control.Invoke(d, new object[] { control, item });
        }
        else
        {
            control.Items.Add(item);
        }
    }
