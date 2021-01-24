    public void HighlightRows()
    {
        var rows = dataGridView1.Rows.OfType<DataGridViewRow>().ToList();
            
        DataGridViewRow row = new DataGridViewRow();
            
        MatchAllRows(rows);
        dataGridView1.DataSource = null;
        dataGridView1.Rows.Clear();
        dataGridView1.Rows.AddRange(rows.ToArray());
    }
    private void MatchAllRows(List<DataGridViewRow> rows)
    {
        for (int i = 0; i < rows.Count() - 1; i++)
            for (int j = i + 1; j < rows.Count(); j++)
                if (rows[i].Cells["age"] == rows[j].Cells["age"])
                    MatchTwoRows(rows[i], rows[j]);
    }
    private void MatchTwoRows(DataGridViewRow row1, DataGridViewRow row2)
    {
        void Match(string key)
        {
            if (row1.Cells[key].Value == row2.Cells[key].Value)
            {
                row1.Cells[key].Style.ForeColor = Color.Red;
                row2.Cells[key].Style.ForeColor = Color.Red;
                row1.Cells[key].Style.BackColor = Color.Yellow;
                row2.Cells[key].Style.BackColor = Color.Yellow;
            }
        }
        List<string> keys = new List<string> { "name", "age", "hobby" };
            
        foreach (string key in keys)
            Match(key);
    }
