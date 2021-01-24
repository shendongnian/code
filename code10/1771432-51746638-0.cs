    var existingRow = dataGridView1.Rows
        .Where(r => Convert.ToString(r.Cells[0].Value) == txtBarcode.Text)
        .SingleOrDefault();
    if(existingRow != null)
    {
        var price = Convert.ToInt64(existingRow.Cells[2].Value);
        var quantity = Convert.ToInt64(existingRow.Cells[3].Value);
        existingRow.Cells[3].Value = quantity + 1;
        existingRow.Cells[4].Value = price * (quantity + 1);
    }
    else
    {
        // Your !found logic
    }
