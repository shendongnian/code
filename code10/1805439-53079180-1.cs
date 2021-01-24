    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        if (dgv.Rows.Count >= e.RowIndex + 1)
        {
            bool isChecked = (bool)dgv.Rows[e.RowIndex].Cells["CheckColumn"].Value;
            MessageBox.Show(string.Format("Row {0} is {1}", e.RowIndex, isChecked));
        }
    }
