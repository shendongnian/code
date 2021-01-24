    public ActionResult ExportDataTableToExcel(string searchBox)
    {
        var fileName = "xxxReport";
        byte[] excelContent;
        // *** code that pulls your data ***
        // always try to use a 'using' statement when you can for disposable objects
        using (var fs = new FileStream(Server.MapPath(@"~/Content/Templates/xxxReport.xlsx"), FileMode.Open, FileAccess.Read))
        using (var excel = new ExcelPackage(fs))
        {
            // *** manipulate your worksheet here ***
            
            excelContent = excel.GetAsByteArray();
        }
        string saveAsFileName = string.Format("{0}_{1:d}.xlsx", fileName, DateTime.Now).Replace("/", "-");
        return File(excelContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", saveAsFileName);
    }
