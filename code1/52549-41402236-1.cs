    byte[] data;
    using (WebClient client = new WebClient())
    {
        ICredentials cred;
        cred = new NetworkCredential("xmen@test.com", "mybestpassword");
        client.Proxy = new WebProxy("192.168.0.1",8000);
        client.Credentials = cred;
        string myurl="http://mytestsite.com/source.jpg";
        data = client.DownloadData(myUrl);
    }
     
    File.WriteAllBytes(@"c:\images\target.jpg", data);
