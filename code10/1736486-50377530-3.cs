    ((DataGridViewComboBoxColumn)dataGridView1
                                .Columns[2])
                                .Items.AddRange(new string[] { "Item1", "Item2", "Item3" });
    ((ComboBoxCell)dataGridView1.Columns[2]
                                .CellTemplate)
                                .DefaultValue(((DataGridViewComboBoxColumn)dataGridView1
                                .Columns[2]).Items[0].ToString());
