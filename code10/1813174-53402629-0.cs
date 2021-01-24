       string[] GetWikiCode(string topic)
        {
            string htmlCode = "";
            string url = "https://en.wikipedia.org/w/index.php?title=" 
                + topic + "&action=raw";
            Console.WriteLine(String.Format("Downloading: {0}", url));
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString(url);
            }
            string[] delimit = new string[] { "\n", "\r\n" };
            string[] result = htmlCode.Split(delimit,
                                  StringSplitOptions.RemoveEmptyEntries);
            return result;
        }
