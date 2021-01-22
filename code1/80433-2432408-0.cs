    NameValueCollection loginData = new NameValueCollection();
    loginData.Add("username", "your_username");
    loginData.Add("password", "your_password");
 
    WebClient client = new WebClient();
    string source = Encoding.UTF8.GetString(client.UploadValues("http://www.site.com/login", loginData));
 
    string cookie = client.ResponseHeaders["Set-Cookie"];
