    private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        ... // (checking goes here)
        e.Value = new MyReal(e.Value.ToString());
        e.ParsingApplied = true;
    }
