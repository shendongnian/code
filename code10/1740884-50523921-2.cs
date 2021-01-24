    void PopulateListView(DataRow[] _foundRows)
    {
        lvDepartments.Items.Clear();
        foreach (var row in _foundRows)
        {
            var item = new ListViewItem { Text = row.Field<String>("NUM") };
            item.SubItems.Add( row.Field<String>("NAM") );
            lvDepartments.Items.Add( item );
        }
    }
