    public static XDocument GetDoc(string uri, int timeout)
    {
        var result = default(XDocument);
        {
            using (var client = new WebClient())
            using (var complete = new ManualResetEvent(false))
            {
                client.DownloadStringCompleted += (sender, e) =>
                {
                    try
                    {
                        if (!e.Cancelled)
                        {
                            result = XDocument.Parse(e.Result);
                        }
                    }
                    finally
                    {
                        complete.Set();
                    }
                };
    
                client.DownloadStringAsync(new Uri(uri));
                Thread.Sleep(timeout);
                if (!complete.WaitOne(1))
                {
                    client.CancelAsync();
                }
                complete.WaitOne();
            }
        }
        return result;
    }
