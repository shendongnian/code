    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      // Determine what column has changed
      var colIndex = e.ColumnIndex;
      var sum = 0;
      foreach (DataGridViewRow row in dataGridView1.Rows)
        // Be aware of what numbers you have in your column!!
        // Then cast it appropriately
        sum += (int)row.Cells[colIndex].Value;
      textBox1.Text = sum.ToString();
    }
