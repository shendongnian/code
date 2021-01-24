    private void GridView_MasterRowExpanded(object sender, CustomMasterRowEventsArgs e)
    {
        var masterView = sender as GridView;
        GridView detailView = masterView?.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
    
        //Make the column read-only
        detailView?.Columns[0].OptionsColumn.ReadOnly = true;
        //Make the column non-editable
        detailView?.Columns[0].OptionsColumn.AllowEdit = false;
    } 
