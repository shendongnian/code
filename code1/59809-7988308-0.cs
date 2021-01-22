    private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
       DataGridView dgv = (DataGridView)sender;
       DataGridViewCell cell = dgv.CurrentCell;
       if (cell.RowIndex >= 0 && cell.ColumnIndex == 3) // My checkbox column
         {
            // If checkbox checked, copy value from col 1 to col 2
            if (dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].EditedFormattedValue != null && dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].EditedFormattedValue.Equals(true))
            {
               dgv.Rows[cell.RowIndex].Cells[1].Value = dgv.Rows[cell.RowIndex].Cells[2].Value;
            }
         }
    }
