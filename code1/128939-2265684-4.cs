    public static IEnumerable<string> FilterRealWords(IEnumerable<string> testWords)
    {
        string baseUrl = "http://en.wiktionary.org/w/api.php?action=query&format=xml&titles=";
        string queryUrl = baseUrl + string.Join("|", testWords.ToArray());
        WebClient client = new WebClient();
        client.Encoding = UnicodeEncoding.UTF8; // this is very important or the text will be junk
        string rawXml = client.DownloadString(queryUrl);
        TextReader reader = new StringReader(rawXml);
        XPathDocument doc = new XPathDocument(reader);
        XPathNavigator nav = doc.CreateNavigator();
        XPathNodeIterator iter = nav.Select(@"//page");
        List<string> realWords = new List<string>();
        while (iter.MoveNext())
        {
            // if the pageid attribute has a value
            // add the article title to the list.
            if (!string.IsNullOrEmpty(iter.Current.GetAttribute("pageid", "")))
            {
                realWords.Add(iter.Current.GetAttribute("title", ""));
            }
        }
        return realWords;
    }
