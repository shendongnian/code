        DataTable sumDataTable = new DataTable();
        sumDataTable.Columns.Add("total", typeof(string));
        sumDataTable.Columns.Add("workedhours", typeof(int));
        sumDataTable.Columns.Add("tfshours", typeof(int));  
             
        DataRow row = sumDataTable .NewRow();
                    for (int j = 0; j < sumDataTable .Columns.Count; j++)
                    {
                            if(sumDataTable .Columns[j].Caption!="total")
                            row[j] = sumDataTable .Compute("Sum([" +                                
                            sumDataTable .Columns[j].Caption + "])", "");                       
                    }
                    sumDataTable .Rows.Add(row);
