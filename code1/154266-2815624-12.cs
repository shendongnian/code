    public void Run()
    {
        string url;
        url = "https://www.ibm.com/developerworks/mydeveloperworks/blogs/roller-ui/rendering/feed/gradybooch/entries/rss?lang=en";
        HttpWebRequest hwr = (HttpWebRequest) WebRequest.Create(url);
        // attach persistent cookies
        hwr.CookieContainer =
            PersistentCookies.GetCookieContainerForUrl(url);
        hwr.Accept = "text/xml, */*";
        hwr.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us");
        hwr.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 3.5.30729;)";
        hwr.KeepAlive = true;
        hwr.AutomaticDecompression = DecompressionMethods.Deflate |
                                     DecompressionMethods.GZip;
        using (var resp = (HttpWebResponse) hwr.GetResponse())
        {
            using(Stream s = resp.GetResponseStream())
            {            
                string cs = String.IsNullOrEmpty(resp.CharacterSet) ? "UTF-8" : resp.CharacterSet;
                Encoding e = Encoding.GetEncoding(cs);
                using (StreamReader sr = new StreamReader(s, e))
                {
                    var allXml = sr.ReadToEnd();
                    // remove any script blocks - they confuse XmlReader
                    allXml = Regex.Replace( allXml,
                                            "(.*)<script type='text/javascript'>.+?</script>(.*)",
                                            "$1$2",
                                            RegexOptions.Singleline);
                    using (XmlReader xmlr = XmlReader.Create(new StringReader(allXml)))
                    {
                        var items = from item in SyndicationFeed.Load(xmlr).Items
                            select item;
                    }
                }
            }
        }
    }
