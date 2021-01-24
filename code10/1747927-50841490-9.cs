    private readonly IServiceContext ctx;
    
    //...
    
    public void Download(string guid) {
        //...get list
        
        using(var fileStream = ExportToXlsx(list)) {
            var contentType = "application/vnd.openxmlformats";
            var fileName = "demo.xlsx";
            var response = ctx.reqobj.HttpContext.Response;
            response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");
            response.ContentType = contentType;
            fileStream.CopyTo(response.Body);
        }
    }
    
