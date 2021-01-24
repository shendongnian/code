    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        dataGridView1.Rows[e.RowIndex].ErrorText = "";
        int result;
    
        // Don't try to validate the 'new row' until finished editing since there
        // is not any point in validating its initial value.
        if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
        if (!int.TryParse(e.FormattedValue.ToString(), out result))
        {
            e.Cancel = true;
            dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be an integer";
        }
        else if(result < 0)
        {
            e.Cancel = true;
            dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be positive";
        }
    }
