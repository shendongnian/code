    // Holds the last selected index
    private int _previousIndex = -1;
    // Restores the previous selection if there are no selections
    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedIndices.Count == 0)
        {
            if (_previousIndex >= 0)
            {
                listView1.SelectedIndices.Add(_previousIndex);
            }
        }
    }
    // Records the last selected index
    private void listView1_ItemSelectionChanged(object sender, 
                   ListViewItemSelectionChangedEventArgs e)
    {
        if (e.IsSelected)
        {
            _previousIndex = e.ItemIndex;
        }
    }
