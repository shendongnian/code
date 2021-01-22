    void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (cell is DataGridViewComboBoxCell)
        {        
            DataGridViewComboBoxCell cell = DataGridViewComboBoxCell)dataGridView1.CurrentCell;
            cell.Items.Clear();
            cell.Items.Add(e.FormattedValue);
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            cell.Value = e.FormattedValue;
        }
    }
