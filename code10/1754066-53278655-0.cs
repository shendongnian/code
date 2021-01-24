    public string excelParsing(string fullpath)
    {
        string data = "";
        //Create COM Objects. Create a COM object for everything that is referenced
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fullpath);
        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        Excel.Range xlRange = xlWorksheet.UsedRange;
    
        int rowCount = xlRange.Rows.Count;
        int colCount = xlRange.Columns.Count;
    
        //iterate over the rows and columns and print to the console as it appears in the file
        //excel is not zero based!!
        for (int i = 1; i <= rowCount; i++)
        {
            for (int j = 1; j <= colCount; j++)
            {
                 //either collect data cell by cell or DO you job like insert to DB 
                if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    data += xlRange.Cells[i, j].Value2.ToString();
            }
        }
    
        return data;
    }
