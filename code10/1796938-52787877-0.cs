    using(SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM services", "PUT YOUR CONN STRING IN A CONFIG FILE")){
        DataTable dt = new DataTable();
        da.Fill(dt);
        using (ExcelPackage ep = new ExcelPackage(newFile))
        {
          ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Sheetname");
          ws.Cells["A1"].LoadFromDataTable(dt, true);
          ep.SaveAs(new FileInfo("YOUR SAVE PATH HERE"));
        }
    }
