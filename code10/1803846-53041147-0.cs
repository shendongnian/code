    [Route("api/documents/{company}/{type}/{id}")]
    public async Task<IHttpActionResult> Post(string company, string type, string id)
    {
    
        string path = System.IO.Path.Combine(Properties.Settings.Default.datafolder, company, type, id);
        if (System.IO.File.Exists(path))
        {
                return BadRequest($"File {path} already exists");
        }
    
        HttpRequest req = HttpContext.Current.Request;
        if (req.Files.Count != 1)
        {
            return BadRequest();
        }
    
        HttpPostedFile file = req.Files[0];
        byte[] buffer = new Byte[file.InputStream.Length];
        await file.InputStream.ReadAsync(buffer, 0, (int)file.InputStream.Length);
        File.WriteAllBytes(path, buffer);
    
        return Ok();
    }
