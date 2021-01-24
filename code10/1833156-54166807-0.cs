    [HttpPost("upload")]
    public async Task<string> Post([FromBody] IFormFile photo)
    {
        try
        {
            // Full path to file in  location
            string fname = DoPhotoUpload(photo);
            string filePath = Path.Combine(_env.WebRootPath, "photos/" + fname);
    
            if (photo.Length > 0)
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await photo.CopyToAsync(stream);
                //return Ok(new { count = 1, path = filePath });
            return fname;
        } catch (Exception ex)
        {
            return ex.Message;
        }
    }
