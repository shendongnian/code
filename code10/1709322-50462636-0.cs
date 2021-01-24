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
	    var fileContent = new StringContent(JsonConvert.SerializeObject(fileObject), Encoding.UTF8, "application/json"); // file content
	    var formDataContent = new MultipartFormDataContent();
	    formDataContent.Add(model.fileContent, "File", model.File.FileName);   		// file
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
