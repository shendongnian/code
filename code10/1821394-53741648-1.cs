    //For .net core 2.1
    [HttpPost]
    public IActionResult Index(List<IFormFile> files)
    {
       //Do something with the files here. 
        return Ok();
    }
    
    
    
    
    //For previous versions
    [HttpPost]
    public IActionResult Index()
    {
        var files = Request.Form.Files;
    	//Do something with the files here. 
    	return Ok();
    }
