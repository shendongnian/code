    using (WebClient webClient = new WebClient())
    {
        try
        {
            using (Stream stream = webClient.OpenRead("http://does.not.exist.com/textfile.txt"))
            {
            }
        }
        catch (WebException)
        {
            throw;
        }
    }
