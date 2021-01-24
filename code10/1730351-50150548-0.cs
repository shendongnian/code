    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(IFormFile myFile)
    {
       // full path to file in temp location, you could change this
       var filePath = Path.GetTempFileName();
       if (myFile.Length > 0)
       {
           using (var stream = new FileStream(filePath, FileMode.Create))
           {
               await myFile.CopyToAsync(stream);
           }
       }
       // process uploaded files
       // Don't rely on or trust the FileName property without validation.
       return Ok(new { filePath, myFile.Length });
    }
