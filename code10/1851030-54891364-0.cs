    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("C1");
        dt.Rows.Add("A");
        dt.Rows.Add("B");
        dt.Rows.Add("C");
        dt.Rows.Add("D");
        var column = new DataGridViewComboBoxColumn();
        column.DataPropertyName = "C1";
        column.Name = "C1";
        column.DataSource = new List<string> { "A", "B" };
        dataGridView1.DataError += (s, a) =>
        {
            if (a.ColumnIndex == 0)
                a.ThrowException = false;
        };
        dataGridView1.CellFormatting += (s, a) =>
        {
            if (a.ColumnIndex == 0)
            {
                a.Value = dataGridView1[a.ColumnIndex, a.RowIndex].Value;
                a.FormattingApplied = true;
            }
        };
        dataGridView1.Columns.Add(column);
        dataGridView1.DataSource = dt;
    }
