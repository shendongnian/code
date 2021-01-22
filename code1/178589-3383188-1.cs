    string result;
    using (WebClient client = new WebClient())
    {
        result = client.DownloadString("http://example.com/string.txt");
    }
    Console.WriteLine(result);
