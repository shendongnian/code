    [HttpPost]
    public IHttpActionResult AddFile()
    {
        var request = HttpContext.Current.Request;
    
        if (request.Files.Count > 0)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                Stream stampStream = request.Files[i].InputStream;
                Byte[] stampBytes = new Byte[stampStream.Length];
                // Save only file name to your database
            }
        }
    
        return Ok();
    }
