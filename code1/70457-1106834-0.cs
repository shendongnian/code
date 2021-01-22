    String url = BuildURI(); //Returns the above URL
    Uri uri = new Uri(url);
    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
    req.Proxy = new WebProxy();
    using (WebResponse resp = req.GetResponse()) {
        using (Stream stream = resp.GetResponseStream()) {
            // whatever
        }
    }
