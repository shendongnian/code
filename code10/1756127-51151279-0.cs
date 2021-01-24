    
    bool IsTheSameCellValue(int column, int row)
    {
        // To compare only values on 1st and 2nd column (TGL, TRANSAKSI)
        if (column > 1) return false;
        DataGridViewCell cell1 = dataGridView[column, row];
        DataGridViewCell cell2 = dataGridView[column, row - 1];
        if (cell1.Value == null || cell2.Value == null)
        {
            return false;
        }
        return cell1.Value.ToString() == cell2.Value.ToString();
    }
    private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        if (e.RowIndex < 1 || e.ColumnIndex < 0)
            return;
        if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
        {
            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        }
        else
        {
            e.AdvancedBorderStyle.Top = dataGridView.AdvancedCellBorderStyle.Top;
        }
    }
    private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex == 0)
            return;
        if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
        {
            e.Value = "";
            e.FormattingApplied = true;
        }
    }
