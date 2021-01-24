        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtselectedcellvalue.Text = dataGridView1.CurrentCell.Value.ToString();
            //txtselectedcellvalue.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.CurrentCell.ColumnIndex].Value.ToString();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedCells.Count > 0)
                txtselectedcellvalue.Text = dataGridView1.CurrentCell.Value.ToString();
              //txtselectedcellvalue.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.CurrentCell.ColumnIndex].Value;
        }
        private void btnchange_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = txtvaluechange.Text;
            //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.CurrentCell.ColumnIndex].Value = txtvaluechange.Text;
        }
