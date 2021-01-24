    private void customDGV1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        DataGridViewCell cell = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
        if (cell.Tag == null) return;
        string hide = cell.Tag.ToString();
        if (hide.Contains("r")) 
           e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
        else 
           e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
    }
 
