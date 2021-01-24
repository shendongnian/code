    public DataTable GetDataTableFromExcel(string path)
    {    
         var tbl = new DataTable();
         using (var pck = new OfficeOpenXml.ExcelPackage())
        {
       //reading the excel file using the stream
        using (var stream = File.OpenRead(path))
        {
          pck.Load(stream);
        }
        
        //Reading the data from the 1st sheet, you can add the code to read other sheets
        var ws = pck.Workbook.Worksheets.First();        
        //now adding the columns to the table and assuming the first row of the sheet is contaning columns if not change the we.Cells property
        foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
        {
           tbl.Columns.Add(firstRowCell.Text);
        }
                       //adding data to datatable
        for (int rowNum = 1; rowNum < ws.Dimension.End.Row; rowNum++)
        {
           var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
           DataRow row = tbl.Rows.Add();
           foreach (var cell in wsRow)
           {
              cell.Calculate();
              row[cell.Start.Column - 1] = cell.Value;
            }
        }
            return tbl;
    }
     
