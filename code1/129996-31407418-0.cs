    public void DataTableToExcel(DataTable dt, string Filename)
    {
        MemoryStream ms = DataTableToExcelXlsx(dt, "Sheet1");
        ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Filename);
        HttpContext.Current.Response.StatusCode = 200;
        HttpContext.Current.Response.End();
    }
	
    public static MemoryStream DataTableToExcelXlsx(DataTable table, string sheetName)
    {
        MemoryStream result = new MemoryStream();
        ExcelPackage excelpack = new ExcelPackage();
        ExcelWorksheet worksheet = excelpack.Workbook.Worksheets.Add(sheetName);
        int col = 1;
        int row = 1;
        foreach (DataColumn column in table.Columns)
        {
            worksheet.Cells[row, col].Value = column.ColumnName.ToString();
            col++;
        }
        col = 1;
        row = 2;
        foreach (DataRow rw in table.Rows)
        {
            foreach (DataColumn cl in table.Columns)
            {
                if (rw[cl.ColumnName] != DBNull.Value)
                    worksheet.Cells[row, col].Value = rw[cl.ColumnName].ToString();
                col++;
            }
            row++;
            col = 1;
        }
        excelpack.SaveAs(result);
        return result;
    }
