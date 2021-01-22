    private void SortByTwoColumns()
    {
        // Get the DefaultViewManager of a DataTable.
        DataView view = DataTable1.DefaultView;
    
        // By default, the first column sorted ascending.
        view.Sort = "State, ZipCode DESC";
    }
