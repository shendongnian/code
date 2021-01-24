    private const string NEW_ITEM_TEXT = "Add new item..";
    private void Form1_Load(object sender, EventArgs e)
    {
        var comboCol = new DataGridViewComboBoxColumn();
        comboCol.Items.AddRange("A", "B", NEW_ITEM_TEXT);
        dataGridView1.Columns.Add(comboCol);
        dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;            
    }
    private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var comboBox = e.Control as ComboBox;
        if (comboBox == null) return;
        comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
        comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
    }
    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataGridViewComboBoxEditingControl editor = sender as DataGridViewComboBoxEditingControl;
        if (editor.SelectedItem.ToString() != NEW_ITEM_TEXT) return;
        Form2 f2 = new Form2();
        f2.Show();
    }
