        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataGridViewComboBoxColumnNumber)
            {
                setCellComboBoxItems(myDataGridView, e.RowIndex, e.ColumnIndex, someObj);
            }
        }
