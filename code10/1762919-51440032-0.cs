    var personalaccesstoken = "bXlfc3VwZXJfcGVyc29uYWxfYWNjZXNzX3Rva2Vu";
    var base64Token = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{personalaccesstoken}"));
     
    using (HttpClient client = new HttpClient())
    {
    	client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Token);
     
    	var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://{your_tfs_server}/DefaultCollection/{project}/_apis/build/builds?api-version=2.0");
    	requestMessage.Content = new StringContent("{\"definition\": {\"id\":" + definitionId + "},\"sourceBranch\":\"$/BRANCH_NAME\"}", Encoding.UTF8, "application/json");
     
    	using (HttpResponseMessage response = client.SendAsync(requestMessage).Result)
    	{
    		response.EnsureSuccessStatusCode();
    	}
    } 
