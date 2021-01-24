    public string GetPageContents()
    {
        string link = "https://www.abc.net.au/news/science/"
        string pageContent = "";
        WebClient web = new WebClient();
        Stream stream;
        stream = web.OpenRead(link);
        using (StreamReader reader = new StreamReader(stream))
        {
            pageContent = reader.ReadToEnd();
        }
        stream.Close();
        return pageContents;
    }
