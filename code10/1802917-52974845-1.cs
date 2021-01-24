    [HttpPost("auxiliaryupload")]
    public async Task<ActionResult> Post([FromForm]IFormFile file)
    {
        var result = new List<string>();
        using (var reader = new System.IO.StreamReader(file.OpenReadStream()))
        {
            while (reader.Peek() >= 0)
                result.Add(await reader.ReadLineAsync());
        }
        return Ok();
    }
