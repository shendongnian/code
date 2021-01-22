    public class BasePage : System.Web.UI.Page
    {
        public void SendExcelFile(string downloadFileName, List<List<string>> data, string worksheetTitle)
        {
            string tempFolder =Request.PhysicalApplicationPath + "temp";
            string tempFileName = tempFolder + "tempFileName.xlsx"
        
            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);
        
            // Generate file using ExcelPackage
            GenerateExcelDoc(tempFileName, data, worksheetTitle);
        
           Response.AddHeader("Content-Disposition", "attachment;filename=" + downloadFileName);
           Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
           Response.AddHeader("Content-Length", new FileInfo(tempFileName).Length.ToString());
           Response.TransmitFile(tempFileName);
        
            File.Delete(tempFileName);
        }
    }
