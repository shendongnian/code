       perhaps this is a more suitable solution use the cell values of the row clicked
     private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          if (e.RowIndex > -1)
          {
            var val = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
          }
        }
