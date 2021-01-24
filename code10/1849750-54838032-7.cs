    [HttpPost("upload")]
    public IActionResult UploadFile([FromForm(Name ="file")] IFormFile resultFile)
    {
        if (resultFile.Length == 0)
    		return BadRequest();
    	else
    	{
    		using (StreamReader reader = new StreamReader(resultFile.OpenReadStream()))
    		{
    			string content = reader.ReadToEnd();
    			//Removed code
    		}
    	}
    }
