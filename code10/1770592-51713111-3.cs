    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        var dt = new DataTable();
        dt.Columns.Add("C1", typeof(bool)).DefaultValue = true;
        dt.Columns.Add("C2", typeof(string));
        dt.Rows.Add(true, "something");
        dt.Rows.Add(false, "something else");
        dataGridView1.Columns.Add(new DataGridViewButtonColumn()
        { DataPropertyName = "C1", Name = "C1", HeaderText = "C1" });
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
        { DataPropertyName = "C2", Name = "C2", HeaderText = "C2" });
        dataGridView1.DataSource = dt;
        dataGridView1.CellFormatting += dgv_CellFormatting;
        dataGridView1.CellContentClick += dgv_CellContentClick;
    }
    private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != 0)
            return;
        var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        if (value != null && value != DBNull.Value)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)value;
    }
    private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != 0)
            return;
        var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        if (value != null && value != DBNull.Value)
            e.Value = (bool)value ? "-" : "+";
    }
