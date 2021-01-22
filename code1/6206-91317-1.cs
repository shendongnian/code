    using (WebClient client = new WebClient ())
    {
        //manipulate request headers (optional)
        client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        //execute request and read response as string to console
        using (StreamReader reader = new StreamReader(client.OpenRead(targetUri)))
        {
            string s = reader.ReadToEnd ();
            Console.WriteLine (s);
        }
    }
