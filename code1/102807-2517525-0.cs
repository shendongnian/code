    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value != null && dataGridView1.Columns[e.ColumnIndex] == theRelevantColumn)
        {
            e.Value = e.Value.ToString();
        }
    }
