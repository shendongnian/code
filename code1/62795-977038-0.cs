    private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
       ListViewItem item = e.Item as ListViewItem;
        if (item != null)
        {
            Book b = (Book) item.Tag;
            b.MakeActive(item.Checked);
        }
    }
