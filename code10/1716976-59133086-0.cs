    public IHostingEnvironment _environment;
    public UploadFilesController(IHostingEnvironment environment) // Create Constructor 
    {
    	_environment = environment;
    }
    
    [HttpPost("UploadFiles")]
    public Task<ActionResult<string>> UploadFiles([FromForm]List<IFormFile> allfiles)
    {
    	string filepath = "";
    	foreach (var file in allfiles)
    	{
    		string extension = Path.GetExtension(file.FileName);
    		var upload = Path.Combine(_environment.ContentRootPath, "FileFolderName");
    		if (!Directory.Exists(upload))
    		{
    			Directory.CreateDirectory(upload);
    		}
    		string FileName = Guid.NewGuid() + extension;
    		if (file.Length > 0)
    		{
    			using (var fileStream = new FileStream(Path.Combine(upload, FileName), FileMode.Create))
    			{
    				file.CopyTo(fileStream);
    			}
    		}
    		filepath = Path.Combine("FileFolderName", FileName);
    	}
    	return Task.FromResult<ActionResult<string>>(filepath);
    }
		
