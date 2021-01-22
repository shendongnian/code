    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    HSSFWorkbook hssfworkbook;
    using (FileStream file = new FileStream(Server.MapPath(strSavePath + strRepFileName), FileMode.Open, FileAccess.Read))
    {
         hssfworkbook = new HSSFWorkbook(file);
    }
    Sheet sheet = hssfworkbook.GetSheet("Book1");
    
    DataTable dt = new DataTable();    //Create datatable 
    dt.Columns.Add();             //Add data columns
    for (int count = 0; count <= sheet.LastRowNum; count++)
    {
        DataRow dr = dt.NewRow();         //Create new data row
    
        //Based on the type of data being imported - get cell value accordingly    
        dr[0] = sheet.GetRow(count).GetCell(0).StringCellValue;   
        //dr[0] = sheet.GetRow(count).GetCell(0).NumericCellValue;
        //dr[0] = sheet.GetRow(count).GetCell(0).RichStringCellValue;
        //dr[0] = sheet.GetRow(count).GetCell(0).DateCellValue;
        //dr[0] = sheet.GetRow(count).GetCell(0).BooleanCellValue;
        dt.Rows.Add(dr);  //Add row to datatable
    }
    
    
