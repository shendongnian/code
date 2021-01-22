    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
       var senderGrid = (DataGridView)sender;
       if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
       {
          if (e.ColumnIndex == dataGridView1.Columns["ColumnName"].Index)
          {
            var row = senderGrid.CurrentRow.Cells;
            string ID = Convert.ToString(row["columnId"].Value); //This is to fetch the id or any other info
            MessageBox.Show("ColumnName selected");
          }
       }
    }
