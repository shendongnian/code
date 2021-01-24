    public Task<HttpResponseMessage> Login(LoginViewModel loginModel)
	{
		var dataList = new List<KeyValuePair<string, string>>();
		dataList.Add(new KeyValuePair<string, string>("grant_type", "password"));
		dataList.Add(new KeyValuePair<string, string>("username", loginModel.Email));
		dataList.Add(new KeyValuePair<string, string>("password", loginModel.Password));
		var request = new HttpRequestMessage()
		{
			RequestUri = new Uri(this.BaseUrl + "token"),
			Method = HttpMethod.Post,
			Content = new FormUrlEncodedContent(dataList)
		};
		return Client.SendAsync(request);
	}
