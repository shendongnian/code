    private object[,] DataTableToObjArr(System.Data.DataTable dt)
    {
        int colCount = 0;
        int rowCount = 0;
        var args = new object[dt.Rows.Count, dt.Columns.Count]; 
        foreach (DataRow dr in dt.Rows)
        {
            colCount = 0;
            object[] items = dr.ItemArray;
    
            foreach (object o in items)
            {
                string nextItem = "";
    
                if (o is DateTime)
                {
                    DateTime test = (DateTime)o;
                    if ((test.Hour == 0) && (test.Minute == 0) && (test.Second == 0))
                    {
                        nextItem = ((DateTime)o).ToString("dd-MMM-yy");
                    }
                    else
                    {
                        nextItem = ((DateTime)o).ToString("dd-MMM-yyyy hh:mm:ss");
                    }
                }
                else
                {
                    nextItem = o.ToString();
                }
                args[rowCount, colCount] = nextItem;
    
                colCount++;
            }
    
            rowCount++;
        }
        return args;
    }
