    using Microsoft.AspNetCore.Http;
    public async void UploadFile(IFormFile csvInput)
    {
    	using (var stream = csvInput.OpenReadStream())
    	{
    		var currentLine = 0;
    		using (var reader = new StreamReader(stream))
    		{
    		...
    		}
    	}
    
    }
