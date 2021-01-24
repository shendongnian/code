    [HttpGet("path/{image}")]
    public FileStreamResult Image(string image)
    {
        var result = new FileStreamResult(new FileStream(
                      Path.Combine(_appEnvironment.ContentRootPath, image),
                      FileMode.Open,
                      FileAccess.Read), "image/<your_mime>");
        return result;
    }
