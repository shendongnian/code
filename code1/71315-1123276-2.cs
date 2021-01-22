    public static void Main()
    {
        using (var conn = new SqlConnection())
        {
            conn.Open();
            using (var cmd = new SqlCommand("", conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr == null)
                    {
                        return;
                    }
                    while (rdr.Read())
                    {
                        ThreadPool.QueueUserWorkItem(
                            CheckConnectionAvailable, rdr[0]);
                    }
                }
            }
        }
    }
    private static void CheckConnectionAvailable(object weburl)
    {
        try
        {
            // If this works, it's a lot simpler
            var strServer = new Uri("http://" + weburl);
            using (var client = new WebClient())
            {
                client.UploadDataCompleted += ClientOnUploadDataCompleted;
                client.UploadDataAsync(
                    strServer, "HEAD", new byte[] {}, strServer);
            }
        }
        catch (WebException x)
        {
            Debug.WriteLine(x);
        }
    }
    private static void ClientOnUploadDataCompleted(
        object sender, UploadDataCompletedEventArgs args)
    {
        if (args.Error == null)
        {
            Debug.WriteLine(string.Format("{0} - OK", args.UserState));
        }
        else
        {
            Debug.WriteLine(string.Format("{0} - Error", args.Error));
        }
    }
