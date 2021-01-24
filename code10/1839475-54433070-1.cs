    private void listBox2_DragDrop(object sender, DragEventArgs e)
    {
        ListBox lb = sender as ListBox;
        if (e.Data != null && e.Data.GetDataPresent(typeof(IList<ListItemsTest>))) {
            lb.DisplayMember = "Name";
            lb.ValueMember = "ID";
            lb.DataSource = e.Data.GetData(typeof(IList<ListItemsTest>));
        }
    }
    private void listBox2_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(IList<ListItemsTest>))) {
            e.Effect = DragDropEffects.Copy;
        }
    }
