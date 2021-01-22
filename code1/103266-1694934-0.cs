    WebClient client = new WebClient();
    using (Stream data = client.OpenRead(@"http://www.cnn.com/"))
    {
        using (StreamReader reader = new StreamReader(data))
        {
            string content = reader.ReadToEnd();
            string pattern = @"((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)";
            MatchCollection matches = Regex.Matches(content, pattern);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at position {1}",
                                  groups[0].Value, groups[0].Index);
            }
        }
    }
