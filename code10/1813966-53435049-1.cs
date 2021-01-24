     List<DataGridViewRow> newRowcheck = new  List<DataGridViewRow>();
     List<DataGridViewRow> newRowUncheck = new List<DataGridViewRow>();
     foreach (DataGridViewRow row in dataGridView1.Rows)
             {
                    if (Convert.ToBoolean(row.Cells[1].Value)==false)
                    {
                        newRowUncheck.Add(row);
                    }
                    else
                    {
                        newRowcheck.Add(row);
                    }
    
    
              }
          dataGridView1.Rows.Clear();
    
                int RowIndex;
    
      for(RowIndex = 0; RowIndex < newRowUncheck.Count; RowIndex++)
         {
           dataGridView1.Rows.Add();
           dataGridView1.Rows[RowIndex].Cells[0].Value = newRowUncheck[RowIndex].Cells[0].Value;
           dataGridView1.Rows[RowIndex].Cells[1].Value = newRowUncheck[RowIndex].Cells[1].Value;
          }
    
    
               dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
    
      for (int i=0; i < newRowcheck.Count; i++)
          {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[i+RowIndex-1].Cells[0].Value = newRowcheck[i].Cells[0].Value;
            dataGridView1.Rows[i+ RowIndex-1].Cells[1].Value = newRowcheck[i].Cells[1].Value;
           }
