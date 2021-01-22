     private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
     {
      // [ Item_id column ] Make sure to use the item_id column index
      if (e.ColumnIndex == 5) 
            {
               userBindingSource.Filter = "Item_Id = " + Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
