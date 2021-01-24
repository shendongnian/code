    private readonly IServiceContext ctx;
    
    //...
    
    public void Download(string guid) {
        //...get list
        
        using(var fileStream = ExportToXlsx(list)) {
            if (fileStream.CanSeek && fileStream.Position != 0) {
                fileStream.Seek(0, SeekOrigin.Begin);
            }
            var contentType = "application/vnd.openxmlformats";
            var fileName = "demo.xlsx";
            var response = ctx.reqobj.HttpContext.Response;
            response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");
            response.Headers.Add("Content-Length", fileStream.Length.ToString());
            response.ContentType = contentType;
            fileStream.CopyTo(response.Body);
        }
    }
    
