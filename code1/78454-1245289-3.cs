    using (var client = new System.Net.WebClient())
    {
        client.Encoding = ...;
        client.Credentials = ...;
        return client.DownloadString("SomeUrl");
    }
