    //ProxyString
    string p = "http://username@password:1.2.3.4:8080";
    //Create Uri (format as previously mentioned)
    p = new Regex("(@)").Replace(p, ":", 1);
    Uri uri = new Uri(Regex.Replace(p, @"(:)(?:(?!.+?@)(?=[\w\d]+?\.))", "@"));
    //Note: This Regex works with IP-Addresses but may not with special Domain Names
    //and certainly not when an '@' is used in the password
    //Create Webproxy
    WebProxy proxy = new WebProxy(uri);
    string[] creds = uri.UserInfo.Split(new char[] { ':' }, 2); //,2 is necessesary when ':' is used in the password
    proxy.Credentials = new NetworkCredential(creds[0], creds[1]);
