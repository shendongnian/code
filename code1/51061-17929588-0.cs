    private ErrorProvider ep = new ErrorProvider();
    private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0)
            return;
        double val;
        Control edit = DGV.EditingControl;
        if (edit != null && ! Double.TryParse(e.FormattedValue.ToString(), out val))
        {
            e.Cancel = true;
            ep.SetError(edit, "Numeric value required");
            ep.SetIconAlignment(edit, ErrorIconAlignment.MiddleLeft);
            ep.SetIconPadding(edit, -20); // icon displays on left side of cell
        }
    }
    
    private void DGV_CellEndEdt(object sender, DataGridViewCellEventArgs e)
    {
        ep.Clear();
    }
