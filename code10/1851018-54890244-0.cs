    public async Task<IActionResult> DownloadFile(string filename)
            {
                try
                {
                    string file = @"c:\temp\test.csv";
    
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(file, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }
    
                    memory.Position = 0;
                    return File(memory, GetMimeType(file), filename);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
