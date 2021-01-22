    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
      // Ignore clicks that are not in our 
      if (e.ColumnIndex == dataGridView1.Columns["MyButtonColumn"].Index && e.RowIndex >= 0) {
        Console.WriteLine("Button on row {0} clicked", e.RowIndex);
      }
    }
