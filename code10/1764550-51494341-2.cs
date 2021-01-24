    public async Task<byte[]> DownloadReport(Token token, int reportId)
    {
	    using(var clientForDL = new System.Net.Http.HttpClient())
	    {    
            clientForDL.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.token_type, token.access_token);
            
            var result = await clientForDL.GetAsync("api/" + ApiVersion + "/LibraryDocument/" + reportId + "/download");
            
            if (!result.IsSuccessStatusCode)
                throw new ApiException("Could not download the report");
            
            var contentBytes = await result.Content.ReadAsByteArrayAsync();
            
            return SevenZipHelper.Decompress(contentBytes);
		}
    }
    
    
    public async Task<Report> GetReport(Token token, int reportId)
    {
	    using(var clientForGet = new System.Net.Http.HttpClient())
        {
            clientForGet.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.token_type, token.access_token);
            
            var result = await clientForGet.GetAsync("api/" + ApiVersion + "/LibraryDocument/" + reportId);
            
            if (!result.IsSuccessStatusCode)
                throw new ApiException("Could not get report");
            
            Report report = await result.Content.ReadAsAsync<Report>();
            
            return report;
        }
    }
