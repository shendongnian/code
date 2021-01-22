    public static string[] GetFiles(string url)
    {
        List<string> files = new List<string>(500);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string html = reader.ReadToEnd();
    
                Regex regex = new Regex("<a href=\".*\">(?<name>.*)</a>");
                MatchCollection matches = regex.Matches(html);
    
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        if (match.Success)
                        {
                            string[] matchData = match.Groups[0].ToString().Split('\"');
                            files.Add(matchData[1]);
                        }
                    }
                }
            }
        }
        return files.ToArray();
    }
