    [HttpGet]
        public void DownloadTable(int id)
        {
            List<Employee> all = db.Employees.Where(x => x.ManagerId == id).ToList();
            String file = "Example.xlsx";
            String path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), file);
            List<string[]> headerRow = new List<string[]>() { new string[] { "EmployeeId", "Name", "Shift", "Timestamp" } };
            string headerRange = "A2:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "2";
            ExcelPackage excel = new ExcelPackage();
            excel.Workbook.Worksheets.Add("Employees");
            var page = excel.Workbook.Worksheets["Employees"];
            page.Cells["A1:D1"].Merge = true;
            page.Cells["A1:D1"].Value = "Supervisor: " + all.FirstOrDefault().Manager + " - " + id;
            page.Cells["A1:D1"].Style.Font.Bold = true;
            page.Cells[headerRange].LoadFromArrays(headerRow);
            int z = 3;
            foreach (Reporte r in all)
            {
                page.Cells["A" + z].Value = r.Id;
                page.Cells["B" + z].Value = r.Name;
                page.Cells["C" + z].Value = r.Shift;
                page.Cells["D" + z].Value = r.Timestamp;
                z++;
            }
            page.Cells["D3:D" + z].Style.Numberformat.Format = "dddd dd MMMM YYYY";
            page.Cells["A2:D2"].AutoFilter = true;
            page.Cells["A1:D" + z].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            page.Cells["A1:D" + z].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            page.Cells["A2:D" + z].AutoFitColumns();
            page.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            page.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(1, 183, 222, 232));
            FileInfo excelFile = new FileInfo(path);
            excel.SaveAs(excelFile);
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition",
                               "attachment; filename=" + file + ";");
            response.TransmitFile(path);
            response.Flush();
            response.End();
            File.Delete(path);
        }
