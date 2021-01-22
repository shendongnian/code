    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    col.Name = "My Enum Column";
    col.DataSource = Enum.GetValues(typeof(MyEnum));
    col.ValueType = typeof(MyEnum);
    dataGridView1.Columns.Add(col);
