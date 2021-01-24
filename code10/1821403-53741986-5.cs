    [HttpPost]
    public HttpResponseMessage Upload(UploadedFile file)
    {
    	if (!ModelState.IsValid)
    		...
    		
    	if (file == null)
    	  	...
    	string destinationPath = Path.Combine(_whateverPath, file.FileFullName);
    	File.WriteAllBytes(destinationPath, file.Data);
    }
