    void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (this.dataGridBebidas.IsCurrentCellDirty)
        {
            // This fires the cell value changed handler below
            dataGridBebidas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
    
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // My combobox column is the second one so I hard coded a 1, flavor to taste
        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridBebidas.Rows[e.RowIndex].Cells[4];
        if (cb.Value != null)
        {
            // Asigno valor de combobox a campo "Alcohol"
            dataGridBebidas.Invalidate();
    
            dataGridBebidas.Rows[e.RowIndex].Cells[3].Value = cb.Value; // Cell I want to update
        }
    }
