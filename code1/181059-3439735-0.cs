    private void dataGridView1_CellFormatting(object sender, 
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0) // Check for the column you want
        {
            e.Value = Path.GetFileName(e.Value.ToString());
            e.FormattingApplied = true;
        }
    }
