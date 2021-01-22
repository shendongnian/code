     public Boolean CompareDataTables(DataTable table1, DataTable table2)
       {
           bool flag = true;
           DataRow[] row3 = table2.Select();
           int i = 0;// row3.Length;
           if (table1.Rows.Count == table2.Rows.Count)
           {
               foreach (DataRow row1 in table1.Rows)
               {
                   if (!row1.ItemArray.SequenceEqual(row3[i].ItemArray))
                   {
                       flag = false;
                       break;
                   }
                   i++;
               }
               
           }
           else
           {
               flag = false;
           }
           return flag;
       }
