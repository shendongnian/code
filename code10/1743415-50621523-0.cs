    private void dataGridViewCND_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.ColumnIndex == 2)
      {
          if (e.Value != null)
           {
              if (e.Value.ToString().Contains("S010"))
              {
                  dataTable.Rows[e.ColumnIndex][e.RowIndex] = "BE";
                  e.Value = "BE";
              }
              else if (e.Value.ToString().Contains("S011"))
              {
                  dataTable.Rows[e.ColumnIndex][e.RowIndex] = "BI";
                  e.Value = "BI";
              }
          }
      }
    }
