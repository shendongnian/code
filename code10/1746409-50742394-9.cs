    [HttpPost("PostDir")]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> PostDir(string serverPath)
    {           
        var zipName = Path.Combine(_config["QuickDrive:TempDir"], Guid.NewGuid() + ".zip");
        using (var fileStream = System.IO.File.Create(zipName))
            await Request.Body.CopyToAsync(fileStream );
        return Ok();
    }
