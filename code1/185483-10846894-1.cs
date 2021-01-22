    private DataTable ConvertList_To_Datatable(ListView lvDetails)
           {
               DataTable dtTable = new DataTable("ExportToPdf");
               if (lvDetails.Items.Count < 1)
               {
                   return dtTable;
               }
               else
               {
                   for (int ncount = 0; ncount <= lvDetails.Columns.Count-1; ncount++)
                   {
                       DataColumn dtColumn =new DataColumn(lvDetails.Columns[ncount].Text);
                       dtTable.Columns.Add(dtColumn);
                   }
               }          
               for (int nRowCount = 0; nRowCount <= lvDetails.Items.Count - 1; nRowCount++)
               {
                   DataRow dtRow = dtTable.NewRow();
                   for (int nItem = 0; nItem <=lvDetails.Items[nRowCount].SubItems.Count - 1; nItem++)
                   {                    
                       dtRow[lvDetails.Columns[nItem].Text] = lvDetails.Items[nRowCount].SubItems[nItem].Text;
                      
                   } dtTable.Rows.Add(dtRow);
    
               } return dtTable;
    
           }
