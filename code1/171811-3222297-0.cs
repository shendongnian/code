    private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
        // TODO: Add proper error handling by checking for null values, 
        // using decimal.TryParse, ...
        var row = dataGridView1.Rows[e.RowIndex];
        int quantity = int.Parse(row.Cells[1].Value.ToString());
        decimal sellingPrice = decimal.Parse(row.Cells[2].Value.ToString());
        row.Cells[3].Value = quantity * sellingPrice;
    }
