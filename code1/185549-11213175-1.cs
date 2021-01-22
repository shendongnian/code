    ListViewItem objListViewItem = new ListViewItem();
    objListViewItem.Text = "Item index: " + e.ItemIndex.ToString();
    if (mblnShow) objListViewItem.SubItems.Add("second column: " +     DateTime.Now.Millisecond.ToString());
    objListViewItem.SubItems.Add("third column: " + DateTime.Now.Millisecond.ToString());
    e.Item = objListViewItem;
