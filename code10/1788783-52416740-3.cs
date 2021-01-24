    [HttpPost]
    public IActionResult UploadFiles()
    {
        //file upload process
        var files = Request.Form.Files;
        string type = Request.Form.Where(x => x.Key == "type").FirstOrDefault().Value;
        string id = Request.Form.Where(x => x.Key == "id").FirstOrDefault().Value;
    
    }
