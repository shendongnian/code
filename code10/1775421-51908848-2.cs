    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        string comboboxSelectedValue = string.Empty;
    
        if (dataGridView1.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
            comboboxSelectedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
    }
