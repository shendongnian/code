    public static void Start()
    {
        //TODO Use a 1st party webpage for connectivity testing.
        var t = new Thread(() =>
        {
            while (!isCancelled)
            {
                try
                {
                    var req = HttpWebRequest.Create("http://example.com");
                    req.Timeout = 1000;
                    var resp = req.GetResponse();
                    resp.Close();
                    IsConnected = true;
                }
                catch (Exception ex)
                {
                    IsConnected = false;
                }
                Console.WriteLine(IsConnected);
                Thread.Sleep(1000);
            }
        });
        t.Start();
    }
