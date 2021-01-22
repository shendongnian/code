     public void WriteToSheet(ref Excel.Workbook targetBook, byte[] fileBytes)
    {
        
        //Create a temp file to encapsulate Byte array
        string tmpPath = IO.Path.ChangeExtension(IO.Path.GetTempFileName(), ".xls");
        My.Computer.FileSystem.WriteAllBytes(tmpPath, fileBytes, false);
        
        //Open temp file with Excel Interop
        Excel.Workbook tmpBook = xlApp.Workbooks.Open(tmpPath);
        
        //Get a reference to the desired sheet
        Excel.Worksheet tmpSheet = (Excel.Worksheet)tmpBook.ActiveSheet;
        
        //Copy the temp sheet into WorkBook specified as "After" parameter
        tmpSheet.Copy(After = targetBook.ActiveSheet);
        
        //Kill the temp file
        My.Computer.FileSystem.DeleteFile(tmpPath);
    }
