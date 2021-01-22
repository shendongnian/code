    private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                var senderGrid = (DataGridView)sender;
                if (e.ColumnIndex == senderGrid.Columns["Opn"].Index && e.RowIndex >= 0)
                {
                    MessageBox.Show("Opn Click");
                }
    
                if (e.ColumnIndex == senderGrid.Columns["VT"].Index && e.RowIndex >= 0)
                {
                    MessageBox.Show("VT Click");
                }
            }
