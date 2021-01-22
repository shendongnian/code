    void Main()
    {
    	//We need a container to store the cookies in.
    	CookieContainer cookies = new CookieContainer();
    	
    	//Request login page to get a session cookie
    	GETHtml("http://www.purevolume.com/login", cookies);
    	
    	//Now we can do login
    	Login("some-user-name", "some-password", cookies);
    }
    
    public bool Login(string Username, string Password, CookieContainer cookies)
    {
    	string poststring = string.Format("username={0}&password={1}&user_login_button.x=63&user_login_button.y=13&user_login_button=login",
    								Username, Password);
    	byte[] postdata = Encoding.UTF8.GetBytes(poststring);
    
    	HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.purevolume.com/login");
    	webRequest.CookieContainer = cookies;
    	webRequest.Method = "POST";
    	webRequest.Referer = "http://www.purevolume.com/login";
    	webRequest.Headers.Add("origin", "http://www.purevolume.com");
    	webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; InfoPath.2; .NET CLR 3.5.21022;";
    	webRequest.ContentType = "application/x-www-form-urlencoded";
    	webRequest.ContentLength = postdata.Length;
    	using (Stream writer = webRequest.GetRequestStream())
    		writer.Write(postdata, 0, postdata.Length);
    
    	using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
    	{
    		//We need to add any response cookies to our cookie container
    		cookies.Add(webResponse.Cookies);
    			
    		//Only for debug
    		using (var stream = new StreamReader(webResponse.GetResponseStream()))
    			System.Diagnostics.Debug.WriteLine(stream.ReadToEnd());
    
    		return (webResponse.StatusCode == HttpStatusCode.OK);
    	}
    }
    
    public string GETHtml(string url, CookieContainer cookies)
    {
    	HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
    	webRequest.CookieContainer = cookies;
    	webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; InfoPath.2; .NET CLR 3.5.21022;";
    	webRequest.Referer = "http://www.purevolume.com/login";
    	
    	using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
    	{		
    		//We need to add any response cookies to our cookie container			
    		cookies.Add(webResponse.Cookies);
    					
    		using (var stream = new StreamReader(webResponse.GetResponseStream()))
    			return stream.ReadToEnd();
    	}
    }
