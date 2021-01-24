    FileInfo fi = new FileInfo("foo.xlsx");
    ExcelPackage excel = new ExcelPackage(fi);
    int sheet = 1;
    foreach (string sql in sqlQueries)
    {
        DataTable dt = new DataTable();
        NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        da.Fill(dt);
        ExcelWorksheet ws = excel.Workbook.Worksheets.Add(string.Format("Sheet{0}", sheet++));
        ws.Cells["A1"].LoadFromDataTable(dt, true);
    }
    excel.Save();
