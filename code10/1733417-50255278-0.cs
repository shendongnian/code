     private void suggestButton_Click(object sender, EventArgs e)
            {
                var dict = getSuggestDict();
                var dataGridViewComboBoxCell = new DataGridViewComboBoxCell
                {
                    DataSource = dict.Keys.ToList()
                };
    
              
                dataGridView[selectedColumn, selectedRow] = dataGridViewComboBoxCell;
                dataGridView.CurrentCell = dataGridView.Rows[selectedRow].Cells[selectedColumn];
                dataGridView.BeginEdit(false);
            }
