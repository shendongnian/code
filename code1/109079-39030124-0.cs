    for (int i = 0; i < MyDataGridView.Columns.Count ;i++ )
      {
          for (int j = 0; j < MyDataGridView.Rows.Count; j++)
          {
               MyDataGridView.Rows[j].Cells[i].Value = DBNull.Value;
          }
      }
