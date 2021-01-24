    private void dataGridView1_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
    {
        var comboBox = e.Control as DataGridViewComboBoxEditingControl;
        var dataGridView = sender as DataGridView;
        if (comboBox != null && dataGridView != null)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.Validating += (obj, args) =>
            {
                var txt = comboBox.Text;
                if (!comboSource.Contains(txt))
                {
                    comboSource.Add(txt);
                    ((DataGridViewComboBoxColumn)dataGridView.CurrentCell.OwningColumn)
                        .DataSource = null;
                    ((DataGridViewComboBoxColumn)dataGridView.CurrentCell.OwningColumn)
                        .DataSource = comboSource;
                    dataGridView.CurrentCell.Value = txt;
                }
            };
        }
    }
