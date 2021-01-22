       private void GetData(string fileName, string tabName)
        {
            Workbook theWorkbook;
    
            Application ExcelObj = null;
            ExcelObj = new Application();
    
            theWorkbook = ExcelObj.Workbooks.Open(fileName,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
    
    
            Sheets sheets = theWorkbook.Worksheets;
            Worksheet worksheet = (Worksheet)sheets[tabName];
    
            Range range = worksheet.get_Range("A1:A1", Type.Missing);
    
            string data = range.Text as string;
    
            //
            // TODO : store the data
            //
    
            theWorkbook.Close(false, fileName, null);
        }
