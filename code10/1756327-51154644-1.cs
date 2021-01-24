    public void HighlightRows()
    {
        var rows = dataGridView1.Rows.OfType<DataGridViewRow>();
        var duplettes = rows.GroupBy(dgvrow => dgvrow.Cells["age"].Value.ToString())
                    .Where(item => item.Count() > 1)
                    .SelectMany(dgvrow => dgvrow.ToList());
        MatchDuplettes(duplettes.ToList());
    }
    private void MatchDuplettes(List<DataGridViewRow> duplettes)
    {
        for (int i = 0; i < duplettes.Count() - 1; i++)
            for (int j = i + 1; j < duplettes.Count(); j++)
                MatchTwoRows(duplettes[i], duplettes[j]);
    }
    private void MatchTwoRows(DataGridViewRow row1, DataGridViewRow row2)
    {
        void Match(string key)
        {
            if (row1.Cells[key] == row2.Cells[key])
            {
                row1.DefaultCellStyle.BackColor = Color.Yellow;
                row2.DefaultCellStyle.BackColor = Color.Yellow;
                row1.Cells[key].Style.ForeColor = Color.Red;
                row2.Cells[key].Style.ForeColor = Color.Red;
            }
        }
        List<string> keys = new List<string> { "name", "age", "hobby" };
            
        foreach (string key in keys)
            Match(key);
    }
