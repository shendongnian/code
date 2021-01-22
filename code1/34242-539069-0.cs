    private void dataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
        if (e.RowIndex < 3) {
            e.Cancel = true;
        }
    }
    private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
        if (e.Row.Index < 3) {
            e.Cancel = true;
        }
    }
