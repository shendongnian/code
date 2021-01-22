    var uri = new Uri("http://api-verify.recaptcha.net/verify"); 
    
    var queryString = string.Format(
    	"privatekey={0}&remoteip={1}&challenge={2}&response={3}", 
    	privateKey, 
    	userIP, 
    	challenge, 
    	response);
    
    var request = (HttpWebRequest)HttpWebRequest.Create(uri);
    
    request.Method = WebRequestMethods.Http.Post;
    request.ContentLength = queryString.Length;
    request.ContentType = "application/x-www-form-urlencoded";
    
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
    	writer.Write(queryString);
    }
    
    string result;
    using (var webResponse = (HttpWebResponse)request.GetResponse())
    {
    	var reader = new StreamReader(webResponse.GetResponseStream()); 
    	result = reader.ReadToEnd();
    }
