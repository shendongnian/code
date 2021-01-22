    private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
       grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    
    private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // do something with grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
    }
