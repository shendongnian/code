    public class ReportFile
    {
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
    
    public async Task<ActionResult> GenerateReport()
    {
        //some code 
        var tempGuid = Guid.NewGuid().ToString();
        StaticData.ReportsTemp[tempGuid] = new ReportFile
        {
            Data = data, // Convert stream to byte array
            ContentType = obj.MediaType,
            FileName = obj.name
        };
        return Content(tempGuid);
    }
    
    public ActionResult DownloadReport(string fileName)
    {
        if (StaticData.ReportsTemp.ContainsKey(fileName))
        {
            ReportFile file = StaticData.ReportsTemp[fileName];
            StaticData.ReportsTemp.Remove(fileName);
    
            if (file.ContentType == MediaTypeNames.Application.Pdf)
            {
                var cd = new ContentDisposition { FileName = file.FileName, Inline = true };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(file.Data, file.ContentType);
            }
        }
        return View("PageNotFound");
    }
