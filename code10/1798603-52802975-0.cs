    DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
    int i = 0;
    column.DataPropertyName = "type";
    column.DataSource = countrys.Select(x => new { Key = i++, Value = x }).ToList();
    column.DisplayMember = "Value";
    column.ValueMember = "Key";
    dataGridView1.Columns.RemoveAt(1);
    dataGridView1.Columns.Insert(1, column);
