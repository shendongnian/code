    string fileName = @"C:\...";
    string password = GetHashedPasswordFromRegistry();
    Excel.Workbook workbook = excelApp.Workbooks.Open( 
        fileName, Type.Missing, Type.Missing,Type.Missing,
        password, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing);
