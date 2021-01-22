        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (dataGridView.Rows[rowIndex].Cells[columnIndex].Selected == true && dataGridView.Columns[columnIndex].Name == "ColumnA")
             {
                   //.... do any thing here.
             }
        }
