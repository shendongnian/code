    public void HandleItemAdded(object sender, ItemAddedEventArgs e)
    {
        ListViewItem item1 = new ListViewItem(txtName.Text);
        item1.SubItems.Add(txtEmail.Text);
        item1.SubItems.Add(txtPhone.Text);
        MyListView.Add(item1);
    }
