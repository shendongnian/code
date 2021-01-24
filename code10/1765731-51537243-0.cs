    private void PreviousData_Click(object sender, EventArgs e)
    {
        var currentRow = DataGridView2.CurrentCell.RowIndex;
        if (currentRow == 0)
            return;
        else
            currentRow--;
        DataGridView2.ClearSelection();
        DataGridView2.CurrentCell = DataGridView2.Rows[currentRow].Cells[0];
        DataGridView2.Rows[currentRow].Selected = true;
    }
    private void NextData_Click(object sender, EventArgs e)
    {
        var currentRow = DataGridView2.CurrentCell.RowIndex;
        if (currentRow == DataGridView2.RowCount - 1)
            return;
        else
            currentRow++;
        DataGridView2.ClearSelection();
        DataGridView2.CurrentCell = DataGridView2.Rows[currentRow].Cells[0];
        DataGridView2.Rows[currentRow].Selected = true;
    }
