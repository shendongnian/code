    private List<string> _listViewData = new List<string>();
    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        _listViewData = GetData(); // fetch the data that will show in the list view
        listView1.VirtualListSize = _listViewData.Count; // set the list size
    }
    // event handler for the RetrieveVirtualItem event
    private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
        if (e.ItemIndex >= 0 && e.ItemIndex < _listViewData.Count)
        {
            e.Item = new ListViewItem(_listViewData[e.ItemIndex]);
        }
    }
