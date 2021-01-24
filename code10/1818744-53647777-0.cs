    private void Form1_Load(object sender, EventArgs e)
    {
        var textBoxColumn = new DataGridViewTextBoxColumn();
        textBoxColumn.Name = "textBoxColumn";
        var comboBoxColumn = new DataGridViewComboBoxColumn();
        comboBoxColumn.Items.AddRange("A", "B", "C");
        comboBoxColumn.Name = "comboBoxColumn";
        dataGridView1.Columns.Add(textBoxColumn);
        dataGridView1.Columns.Add(comboBoxColumn);
        dataGridView1.Rows.Add("1", "A");
        dataGridView1.Rows.Add("2", "B");
    }
