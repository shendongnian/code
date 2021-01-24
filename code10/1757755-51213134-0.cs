    for (int i = 1; i < enrollmentDataGrid.Columns.Count + 1; i++)
                        {
                           worksheet.Cells[1, i] = enrollmentDataGrid.Columns[i - 1].HeaderText;
    
                        }
    					
    					
    					
    					
     for (int i = 0; i < enrollmentDataGrid.Rows.Count - 1; i++)
         {
          for (int j = 0; j < enrollmentDataGrid.Columns.Count; j++)
             {
                   worksheet.Cells[i + 2, j + 1] = enrollmentDataGrid.Rows[i].Cells[j].Value.ToString();
              }
    
           }
