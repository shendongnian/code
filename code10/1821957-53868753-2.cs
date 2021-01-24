    //ProxyString
    Uri uri = new Uri("http://username:password@1.2.3.4:8080");
    //Create Webproxy
    WebProxy proxy = new WebProxy(uri);
    string[] creds = uri.UserInfo.Split(new char[] { ':' }, 2); //,2 is necessesary when ':' is used in the password
    proxy.Credentials = new NetworkCredential(creds[0], creds[1]);
