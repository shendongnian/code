    [HttpGet]
    public async Task<IActionResult> Download(string id) {
    
        //...
    
        Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
    
        var response = await _oApi.Swift.GetObject(containerName, fileName);
    
        if(response.IsSuccess) {
            return new FileStreamResult(response.Stream, "application/octet-stream");
        }
    
        return new NotFoundResult();
    }
