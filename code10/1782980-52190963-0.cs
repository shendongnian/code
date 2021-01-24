    var cookies = new CookieContainer();
    HttpWebRequest webRequest = WebRequest.Create(URL) as HttpWebRequest;
    webRequest.CookieContainer = cookies;
    var response = (HttpWebResponse)webRequest.GetResponse();
    using (var responseReader = new StreamReader(response.GetResponseStream())) {
        var responseCookies = response.Cookies;
        string responseData = responseReader.ReadToEnd();
        //...
    }
