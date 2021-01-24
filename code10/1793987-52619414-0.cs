    using (FileStream stream = new FileStream("test.xlsx", FileMode.Create))
    using (ExcelPackage package = new ExcelPackage())
    {
    	ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("My Data");
    	Color bgcolor = ColorTranslator.FromHtml("#00FFFF");
    	worksheet.Cells["A1:B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
    	worksheet.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(bgcolor);
    	worksheet.Cells["A1"].Value = "Hello";
    	worksheet.Cells["B1"].Value = "World!";
    	package.SaveAs(stream);
    }
