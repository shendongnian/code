    public void dataGridView_Cellformatting(object sender, DataGridViewCellFormattingEventArgs args)
    {
        if(args.ColumnIndex == 9) //Might be 8, I don't remember if columns are 0-based or 1-based
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            args.Value = (int)row.Cells[6].Value - (int)row.Cells[5].Value;
        }
    }
