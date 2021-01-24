    private void btn_ExportToExcel_Click(object sender, EventArgs e) {
      using (var p = new ExcelPackage()) {
        var ws = p.Workbook.Worksheets.Add("MySheet");
        ws.Cells["A1"].LoadFromDataTable(dt, true);
        p.SaveAs(new FileInfo(@"D:\Test\ExcelFiles\EpplusExport.xlsx"));
      }
    }
