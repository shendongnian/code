	public async Task<List<HomeViewModel>> GetUserJobs(LoginResult token) {
		var result = new List<HomeViewModel>();
		string url = "JobHeaders?userName=" + token.userName;
		HttpResponseMessage httpResponse =  await _requestHelper.GetHttpResponse(url, token.access_token);
		result = await GetJobResponse(httpResponse);
		return result;
	}
		
