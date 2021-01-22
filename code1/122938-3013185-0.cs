    private void dataGridView1_CellFormatting(object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            e.Value = e.Value.ToString().Substring(0, 5); // apply formating here
            e.FormattingApplied = true;
        }
    }
