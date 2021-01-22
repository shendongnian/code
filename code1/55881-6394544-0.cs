    GridView _gridView = new GridView();
    _gridView.Columns.Add(
        new GridViewColumn 
        {
            DisplayMemberBinding = new Binding("columnTitle"), 
            Header = "columnHeader", 
            Width = double.NaN 
        });
