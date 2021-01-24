    [HttpPost("UploadFiles")]
    public async Task<IActionResult> Post(List<IFormFile> files)
    {
        long size = files.Sum(f => f.Length);
    
        // full path to file in temp location
        var filePath = Path.GetTempFileName();
    
        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
        }
