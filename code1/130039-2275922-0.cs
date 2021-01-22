    public static void SendExcelFile(string downloadFileName, List<List<string>> data, string worksheetTitle)
    {
        var context = HttpContext.Current;
        string tempFolder = context.Request.PhysicalApplicationPath + "temp";
        string tempFileName = tempFolder + "tempFileName.xlsx"
    
        if (!Directory.Exists(tempFolder))
            Directory.CreateDirectory(tempFolder);
    
        // Generate file using ExcelPackage
        GenerateExcelDoc(tempFileName, data, worksheetTitle);
    
        context.Response.AddHeader("Content-Disposition", "attachment;filename=" + downloadFileName);
        context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        context.Response.AddHeader("Content-Length", new FileInfo(tempFileName).Length.ToString());
        context.Response.TransmitFile(tempFileName);
    
        File.Delete(tempFileName);
    }
