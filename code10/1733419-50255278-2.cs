    private void suggestButton_Click(object sender, EventArgs e)
    {    
      dataGridView.CurrentCell = dataGridView.Rows[selectedRow].Cells[selectedColumn];
       dataGridView.BeginEdit(true);
        
         var dict = getSuggestDict();
         var dataGridViewComboBoxCell = new DataGridViewComboBoxCell
         {
            DataSource = dict.Keys.ToList()
         };
            
                      
    dataGridView[selectedColumn, selectedRow] = dataGridViewComboBoxCell;
                        
    }
