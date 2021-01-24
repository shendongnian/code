    {
        Workbook workbook = new Workbook();
        Worksheet sheet = workbook.Worksheets[0];
        DataTable dt = GetData();
        
        //Set the number format of the first column as text
        //sheet.Columns[0].NumberFormat = "@";
        sheet.InsertDataTable(dt, false, 1, 1, false);
    
        workbook.SaveToFile("InsertData.xlsx", ExcelVersion.Version2010);
    }
    
    private static DataTable GetData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("column1", typeof(string));
        dt.Columns.Add("column2", typeof(DateTime));
        DataRow row = dt.NewRow();
        row[0] = "92995E85";
        row[1] = "00:00";
        dt.Rows.Add(row);
        row = dt.NewRow();
        row[0] = "333";
        //row[1] = "2";
        dt.Rows.Add(row);
        return dt;
    }
