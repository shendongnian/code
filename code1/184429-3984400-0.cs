    string uri = "https://www.virginmobile.com.au/selfcare/MyAccount/LogoutLoginPre.jsp?username=0466651800&password=160392";
    string parameters = "username=0411223344&password=123456";
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
    req.Method = "GET";
    req.ContentType = "application/x-www-form-urlencoded";
    //req.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.2)     Gecko/20100316 Firefox/3.6.2 ( .NET CLR 3.0.4506.2152)";
    //req.Referer = "http://www.virginmobile.com.au/";
    //req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
    req.AllowAutoRedirect = false;
    // Send the Post
    byte[] paramBytes = Encoding.ASCII.GetBytes(parameters);
    //req.ContentLength = paramBytes.Length
    //Dim reqStream As Stream = req.GetRequestStream()
    //reqStream.Write(paramBytes, 0, paramBytes.Length)
    //Send it
    //reqStream.Close()
    // Get the response
    HttpWebResponse response__1 = (HttpWebResponse)req.GetResponse();
    if (response__1 == null) {
	throw new Exception("Response is null");
    }
    if (!string.IsNullOrEmpty(response__1.Headers("Location"))) {
	string newLocation = response__1.Headers("Location");
	// Request the new location
	req = (HttpWebRequest)WebRequest.Create(newLocation + "?" + parameters);
	req.Method = "GET";
	req.ContentType = "application/x-www-form-urlencoded";
	req.AllowAutoRedirect = false;
	req.CookieContainer = new CookieContainer();
	req.CookieContainer.Add(response__1.Cookies);
	// Send the Post
	//paramBytes = Encoding.ASCII.GetBytes(parameters)
	//req.ContentLength = paramBytes.Length
	//Dim reqStream As Stream = req.GetRequestStream()
	//reqStream.Write(paramBytes, 0, paramBytes.Length)
	//Send it
	//reqStream.Close()
	// Get the response
	//**** The remote server returned an error: (404) Not Found.
	response__1 = (HttpWebResponse)req.GetResponse();
    }
    StreamReader sr = new StreamReader(response__1.GetResponseStream());
    string responseHtml = sr.ReadToEnd().Trim();
