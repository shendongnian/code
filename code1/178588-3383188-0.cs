    string result;
    using (WebClient client = new WebClient())
    {
        result = DownloadString("http://example.com/string.txt");
    }
    Console.WriteLine(result);
