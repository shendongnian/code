    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
        DataGridViewCell currentCell = dataGridView.CurrentCell;
        if (currentCell != null)
        {
            int nextRow = currentCell.RowIndex;
            int nextCol = currentCell.ColumnIndex + 1;
            if (nextCol > dataGridView.ColumnCount)
            {
                nextCol = 0;
                nextRow++;
            }
            if (nextRow > dataGridView.RowCount)
            {
                nextRow = 0;
            }
            DataGridViewCell nextCell = dataGridView.Rows[nextRow].Cells[nextCol];
            if (nextCell != null && nextCell.Visible)
            {
                dataGridView.CurrentCell = nextCell;
            }
        }
    }
