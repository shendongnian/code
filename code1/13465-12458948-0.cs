    /// <summary>
    /// Sending file via multipart\form-data
    /// </summary>
    /// <param name="url">URL for send</param>
    /// <param name="file">Local file path</param>
    /// <param name="paramName">Request file param</param>
    /// <param name="contentType">Content-Type file headr</param>
    /// <param name="nvc">Additional post params</param>
    private static string httpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
    {
    	//delimeter
    	var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
    
    	//creating request
    	var wr = (HttpWebRequest)WebRequest.Create(url);
    	wr.ContentType = "multipart/form-data; boundary=" + boundary;
    	wr.Method = "POST";
    	wr.KeepAlive = true;
    
    	//sending request
    	using(var requestStream = wr.GetRequestStream())
    	{
    		using (var requestWriter = new StreamWriter(requestStream, Encoding.UTF8))
    		{
    			//params
    			const string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
    			foreach (string key in nvc.Keys)
    			{
    				requestWriter.Write(boundary);
    				requestWriter.Write(String.Format(formdataTemplate, key, nvc[key]));
    			}
    			requestWriter.Write(boundary);
    
    			//file header
    			const string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
    			requestWriter.Write(String.Format(headerTemplate, paramName, file, contentType));
    
    			//file content
    			using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
    			{
    				fileStream.CopyTo(requestStream);
    			}
    
    			requestWriter.Write("\r\n--" + boundary + "--\r\n");
    		}
    	}
    
    	//reading response
    	try
    	{
    		using (var wresp = (HttpWebResponse)wr.GetResponse())
    		{
    			if (wresp.StatusCode == HttpStatusCode.OK)
    			{
    				using (var responseStream = wresp.GetResponseStream())
    				{
    					if (responseStream == null)
    						return null;
    					using (var responseReader = new StreamReader(responseStream))
    					{
    						return responseReader.ReadToEnd();
    					}
    				}
    			}
    
    			throw new ApplicationException("Error while upload files. Server status code: " + wresp.StatusCode.ToString());
    		}
    	}
    	catch (Exception ex)
    	{
    		throw new ApplicationException("Error while uploading file", ex);
    	}
    }
