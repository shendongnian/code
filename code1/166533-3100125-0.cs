    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        DataGrid child = e.Item.FindControl("theNestedGrid") as DataGrid;
        if(child != null)
        {
             // Binding logic here
        }
    }
