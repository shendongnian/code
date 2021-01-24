    // Enable AllowUserToAddRows
    dgv.AllowUserToAddRows = true;
    private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        // If button clicked
        if (e.ColumnIndex == 0)
        {
            // Get values what you want to use
            var value1 = dgv.Rows[e.RowIndex].Cells[1].Value;
            var value2 = dgv.Rows[e.RowIndex].Cells[2].Value;
            // Insert a new row behind the click one
            dgv.Rows.Insert(e.RowIndex + 1);
            // Set the previously stored values
            dgv.Rows[e.RowIndex + 1].Cells[1].Value = value1;
            dgv.Rows[e.RowIndex + 1].Cells[2].Value = value2;
        }
    }
