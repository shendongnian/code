    [HttpPost("/Exemplos/UploadFilesAjax")]
    public IActionResult UploadFilesAjax()
    {
        long size = 0;
        var files = Request.Form.Files;
        foreach (var file in files)
        {
            var filename = ContentDispositionHeaderValue
                                            .Parse(file.ContentDisposition)
                                            .FileName
                                            .Trim('"');
            filename = hostingEnv.WebRootPath + $@"\{filename}";
            size += file.Length;
            using (FileStream fs = System.IO.File.Create(filename))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
        string message = $"{files.Count} file(s) / {size} bytes uploaded successfully!";
        return Json(message);
    }
