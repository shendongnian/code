    DataGridViewComboBoxColumn newColumn = new DataGridViewComboBoxColumn();
    newColumn.Name = "abc";
    newColumn.DataSource = new string[] { "a", "b", "c" };
    dataGridView1.Columns.Add(newColumn);
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["abc"]);
        cell.DataSource = new string[] { "a", "c" };
    }
