	var processMsgHander = new ProgressMessageHandler(new HttpClientHandler());
	processMsgHander.HttpSendProgress += (sender, e) =>
		{
			//add your codes base on e.BytesTransferred and e.ProgressPercentage
		};
	processMsgHander.HttpReceiveProgress += (sender, e) =>
		{
			e.BytesTransferred.Dump();
			//add your codes base on e.BytesTransferred and e.ProgressPercentage
		};
	var client = new HttpClient(processMsgHander);
	client.BaseAddress = new Uri("http://mypage.com/");
	var login = await client.GetAsync("http://mypage.com/login");
	var text = await login.Content.ReadAsStringAsync();
	var doc = new HtmlDocument();
	doc.LoadHtml(text);
	var hiddenInput = doc.DocumentNode.SelectNodes("//form//input[@type=\"hidden\"]");
	var loginData = new Dictionary<string, string>();
	foreach (var x in hiddenInput)
	{
		loginData[x.Attributes.First(t => t.Name == "name").Value] = x.Attributes.First(t => t.Name == "value").Value;
	}
	loginData["username"] = "MyUsername";
	loginData["password"] = "MyPasswordShouldntBeHere";
	var lginData = new FormUrlEncodedContent(loginData.ToArray());
	var response = await client.PostAsync(login.RequestMessage.RequestUri, lginData);
	var tF = DateTime.Now;
	var file = await client.GetAsync("http://mypage.com/file");
	var headers = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, "http://mypage.com/file"));
	var tE = DateTime.Now;
	file.Content.Headers.ElementAt(1).Dump(); // if only this is called then the file is downloaded
	headers.Content.Headers.ElementAt(1).Dump(); // if only this is called then the file is not downloaded
	// in my use case either the first line of the second will be called at one case
	// (accordingly the var file and var headers won't both be called)
	(tE - tF).Dump();
