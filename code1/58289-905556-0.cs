    private bool _populating = false;
    private void PopulateListBox(ListBox lb, ReportColumnList reportColumnList)
    {
        _populating = true;
        lb.DataSource = reportColumnList.ReportColumns;
        lb.DisplayMember = "ColumnName";
        lb.ValueMember = "ColumnName";
        // clear the automatically made selection
        lb.SelectedIndex = -1;
        _populating = false;
    }
    private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!_populating)
        {
            // perform the action associated with selecting an item
        }
        
    }
