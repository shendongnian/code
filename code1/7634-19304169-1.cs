    public static class  GetallFilesFromHttp
    {
        public static string GetDirectoryListingRegexForUrl(string url)
        {
            if (url.Equals("http://ServerDirPath/"))
            {
                return "\\\"([^\"]*)\\\""; 
            }
            throw new NotSupportedException();
        }
        public static void ListDiractory()
        {
            string url = "http://ServerDirPath/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string html = reader.ReadToEnd();
                   
                    Regex regex = new Regex(GetDirectoryListingRegexForUrl(url));
                    MatchCollection matches = regex.Matches(html);
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            if (match.Success)
                            {
                                Console.WriteLine(match.ToString());
                            }
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
 
