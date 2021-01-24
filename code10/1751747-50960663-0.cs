    public async Task<HttpResponseMessage> UploadFile(
	string url, 
	byte[] fileContent,
	string fileName,
	List<KeyValuePair<string, string>> headers = null,
	int timeoutMili = 30000)
	{
		HttpResponseMessage retVal = null;
		HttpClientHandler httpClientHandler = null;
		try
		{
			//ssl
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
			ServicePointManager.SecurityProtocol = m_SecurityProtocolType;
			//proxy
			if (m_Proxy != null)
			{
				httpClientHandler = new HttpClientHandler()
				{
					Proxy = m_Proxy
				};
			}
			//create the request
			using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
			{
				using (var content = new MultipartFormDataContent())
				{
					HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
					content.Add(new StreamContent(new MemoryStream(fileContent)), fileName, fileName);
					request.Content = content;
					if (headers != null)
					{
						foreach (var header in headers)
						{
							request.Headers.Add(header.Key, header.Value);
						}
					}
					//send the request
					var cancelToken = new CancellationTokenSource(timeoutMili);
					retVal = await client.SendAsync(request, cancelToken.Token);
				}
			}
		}
		catch (Exception ex)
		{
			throw;
		}
		return retVal;
	}
