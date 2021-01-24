    public async Task<bool> Upload(FileUploadRequest model)
    {
	    var httpClientHandler = new HttpClientHandler()
	    {
		  Proxy = new WebProxy("proxyAddress", "proxyPort")
		  {
			Credentials = CredentialCache.DefaultCredentials
		  },
		  PreAuthenticate = true,
		  UseDefaultCredentials = true
	    };
	    var fileContent = new StreamContent(model.File.OpenReadStream())
        {
           Headers =
           {
               ContentLength = model.File.Length,
               ContentType = new MediaTypeHeaderValue(model.File.ContentType)
           }
        };
	    var formDataContent = new MultipartFormDataContent();
	    formDataContent.Add(fileContent, "File", model.File.FileName);   		// file
	    formDataContent.Add(new StringContent("Test Full Name"), "FullName");   // form input
	    using (var client = new HttpClient(handler: httpClientHandler, disposeHandler: true))
	    {
		    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
		    using (var res = await client.PostAsync("http://filestorageurl", formDataContent))
		    {
			   return res.IsSuccessStatusCode;
		    }
	    }
    }
