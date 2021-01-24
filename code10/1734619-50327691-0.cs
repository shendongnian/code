    //This Code is written in CellClick Event not in CellContentClick (Don'tconfuse with signature)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
               
                dataGridView1.BeginEdit(true);
                var selectedRow = (sender as DataGridView).CurrentCell.RowIndex;
                var selectedColumn = (sender as DataGridView).CurrentCell.ColumnIndex;
                var comboBoxCell = new DataGridViewComboBoxCell
                {
    
                };
                dataGridView1.CurrentCell = dataGridView1.CurrentCell as DataGridViewComboBoxCell;
                dataGridView1[selectedColumn, selectedRow] = comboBoxCell;
                dataGridView1.CurrentCell = dataGridView1.Rows[selectedRow].Cells[selectedColumn];
               dataGridView1.BeginEdit(false);
            }
