    WebRequest request = HttpWebRequest.Create(this.RssUrl);
    request.Timeout = Timeout.Infinite;
    using (WebResponse response = request.GetResponse())
    using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
    {
        // Blah blah...
    }
