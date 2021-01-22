    AutoResetEvent sync = new AutoResetEvent(false);
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://...");
    request.Proxy.Credentials = CredentialCache.DefaultCredentials;
    request.BeginGetResponse((result) =>
    {
        StringBuilder content = new StringBuilder();
        using (HttpWebResponse response = 
               request.EndGetResponse(result) as HttpWebResponse)
        using (Stream stream = response.GetResponseStream())
        {
            int read = 1;
            byte[] buffer = new byte[0x1000];
            while (read > 0)
            {
                read = stream.Read(buffer, 0, buffer.Length);
                content.Append(Encoding.UTF8.GetString(buffer
                    .TakeWhile((b, index) => index <= read)
                    .Where(b => b != 0x00).ToArray()));
            }
            Console.WriteLine(content);
            sync.Set();
        }
    }, null);
    sync.WaitOne();
