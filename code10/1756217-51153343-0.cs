    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int quantity,rate;
            if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["quantity"].Value.ToString(), out quantity) && int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["rate"].Value.ToString(), out rate))
            {
                int price = quantity * rate;
                dataGridView1.Rows[e.RowIndex].Cells["price"].Value = price.ToString();
             }
        }
