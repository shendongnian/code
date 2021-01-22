    using (var w = new WebClient())
    {
        string clientID = "<<INSERT YOUR ID HERE>>";
        w.Headers.Add("Authorization", "Client-ID " + clientID);
        var values = new NameValueCollection
        {
            { "image", Convert.ToBase64String(File.ReadAllBytes(@"hello.png")) }
        };
        byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);
        Console.WriteLine(XDocument.Load(new MemoryStream(response)));
    }
