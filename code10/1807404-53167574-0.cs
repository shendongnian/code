    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                MessageBox.Show(value);
            }
    }
