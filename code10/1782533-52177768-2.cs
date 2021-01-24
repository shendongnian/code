    [HttpGet]
    public FileResult DownloadFile(string fileName)
    {
        if (TempData["bytes"] != null)
        {
            var content = TempData["bytes"] as byte[];
            return File(content, "application/octet-stream", fileName);
        }    
        else
        {
            return new EmptyResult();
        }
    }
