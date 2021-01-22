    private void UpdatePosition(GridView gridView, string columnName, Control control)
    {
        var column = gridView.Columns[columnName];
    
        if (column == null) return;
    
        var viewInfo = (GridViewInfo)gridView.GetViewInfo(); //using DevExpress.XtraGrid.Views.Grid.ViewInfo
        var columnInfo = viewInfo.ColumnsInfo[column];
    
        if (columnInfo != null)
        {
            var bounds = columnInfo.Bounds; //column's rectangle of coordinates relative to GridControl
    
            var point = PointToClient(gridView.GridControl.PointToScreen(bounds.Location)); //translating to form's coordinates
    
            control.Left = point.X;
            control.Top = point.Y - control.Height;
            control.Width = bounds.Width;
    
            control.Show();
        }
        else
            control.Hide();
    }
