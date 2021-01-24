    MyClass json = new MyClass
    {
    	Login = Login
    };
    
    string stringLogin = await Task.Run(() => JsonConvert.SerializeObject(logIn));
    
    string URI = BaseUrl + urlPart;
    string myParameters = "json=" + stringLogin;
    try
    {
    	using (WebClient wc = new WebClient())
    	{
    		wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
    		wc.Encoding = Encoding.UTF8;
    		string HtmlResult = wc.UploadString(URI, "POST", myParameters);
    		result = JsonConvert.DeserializeObject<Result>(HtmlResult);
    	}
    }
    catch (Exception e)
    {
    	Console.WriteLine(e.Message);
    }
