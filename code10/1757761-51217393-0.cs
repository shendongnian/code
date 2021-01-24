    for (int i = 1; i < columnCount + 1; i++)
                        {
                            worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
    
                        }
  
     for (int i = 0; i < rowCount -1; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                worksheet.Cells[i+2, j+1].Value2 = enrollmentDataGrid.Columns[j].GetCellContent(enrollmentDataGrid.Items[i]);
            }
         }
