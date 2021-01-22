    var nvc = new NameValueCollection();
    nvc.Add("email", "my@email.com");
    nvc.Add("password", "password");
    
    var wc = new WebClient();
    byte[] responseArray = wc.UploadValues("http://mysite.com",nvc);
    string responseText = Encoding.ASCII.GetString(responseArray));
