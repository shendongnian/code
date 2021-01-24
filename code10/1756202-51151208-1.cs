    private bool isDisabled = false;
    
    private bool IsDisabled(int row, GridColumn col)
    {
        if (col.FieldName == "somename")
            return isDisabled;
        return false;
    }
    private void GridView_ShowingEditor(object sender, CancelEventArgs e)
    {
        var gv = sender as GridView;
        e.Cancel = IsDisabled(gv.FocusedRowHandle, gv.FocusedColumn);
    }
    private void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
    {
        if(IsDisabled(e.RowHandle, e.Column))
        {
            e.Appearance.BackColor = Color.Gray;
            e.Appearance.Options.UseBackColor = true;
        }
    }
