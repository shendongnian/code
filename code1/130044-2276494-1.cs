    public static void SendExcelFile(System.Web.UI.Page callingPage, string downloadFileName, List<List<string>> data, string worksheetTitle)
    {
        string tempFileName = Path.GetTempFileName();
    
        try
        {
            // Generate file using ExcelPackage
            GenerateExcelDoc(tempFileName, data, worksheetTitle);
    
            callingPage.Response.AddHeader("Content-Disposition", "attachment;filename=" + downloadFileName);
            callingPage.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            callingPage.Response.AddHeader("Content-Length", new FileInfo(tempFileName).Length.ToString());
            callingPage.Response.TransmitFile(tempFileName);
            callingPage.Response.Flush();  //This is what I needed
        }
        finally
        {
            if (File.Exists(tempFileName))
                File.Delete(tempFileName);  
        }
    }
