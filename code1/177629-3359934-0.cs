    public bool Login(string Username, string Password, CookieContainer cookies)
    {
    	string poststring = "username=" + Username + "&password=" + Password;
    	byte[] postdata = Encoding.UTF8.GetBytes(poststring);
    
    	HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.purevolume.com/login");
    	webRequest.CookieContainer = cookies;
    	webRequest.Method = "POST";
    	webRequest.ContentType = "application/x-www-form-urlencoded";
    	webRequest.ContentLength = postdata.Length;
    	using (Stream writer = webRequest.GetRequestStream())
    		writer.Write(postdata, 0, postdata.Length);
    
    	using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
    	{
    		//Only for debug
    		using (var stream = new StreamReader(webResponse.GetResponseStream()))
    			System.Diagnostics.Debug.WriteLine(stream.ReadToEnd());
    			
    		return (webResponse.StatusCode == HttpStatusCode.OK)
    	}
    }
