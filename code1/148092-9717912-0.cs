      if (e.ColumnIndex == dataGridViewMain.Columns["ImageColumn"].Index)
      {
      lblShowCellData.Text = dataGridViewMain.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
      // Do some thing else....
      }
