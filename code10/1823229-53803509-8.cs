    var c = new DataGridViewComboBoxColumn();
    c.DataPropertyName = "Column1"; //Name of your data column
    c.HeaderText = "Column1";       //Header text of your data column
    c.DataSource = new[] {
        new { Key = 0, Name = "Low" },
        new { Key = 1, Name = "High" } }.ToList();
    c.ValueMember = "Key";
    c.DisplayMember = "Name";
    c.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;  
    //You can try other styles as well as setting `ReadOnly` to true
    dataGridView1.Columns.Add(c);
