    using (var w = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "key", "433a1bf4743dd8d7845629b95b5ca1b4" },
            { "image", Convert.ToBase64String(File.ReadAllBytes(@"hello.png")) }
        };
        byte[] response = w.UploadValues("http://imgur.com/api/upload.xml", values);
        Console.WriteLine(XDocument.Load(new MemoryStream(response)));
    }
