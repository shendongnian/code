    Regex hrefs = new Regex("<a href.*?>");
    Regex http = new Regex("(http:.*?)\"");  
    StringBuilder sb = new StringBuilder();
    WebClient client = new WebClient();
    string source = client.DownloadString("http://google.com");
    foreach (Match m in hrefs.Matches(source))
    {
        var value = http.Match(m.ToString()).Groups[1].Value;
        sb.Append(value);
        Console.WriteLine(value);
    }
