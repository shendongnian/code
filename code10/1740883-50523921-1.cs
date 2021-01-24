    void PopulateListView(DataRow[] _foundRows)
    {
        lvDepartments.Items.Clear();
        lvDepartments.Items.AddRange
        (
            _foundRows.Select
            ( 
                row =>
                {
                    var item = new ListViewItem
                    {
                        Text = row.Field<string>("NUM")
                    };
                    item.SubItems.Add( row.Field<string>("NAME") );
                    return item;
                }
            )
            .ToArray()
        );
    }
