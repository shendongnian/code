    public static void Main()
    {
        // Don't mind the interpretation. I needed an excuse to define "rdr"
        using (var conn = new SqlConnection())
        {
            conn.Open();
            using (var cmd = new SqlCommand("SELECT Url FROM UrlsToCheck", conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // Use the thread pool. Please.
                        ThreadPool.QueueUserWorkItem(
                            delegate(object weburl)
                                {
                                    // I invented a reason for you to return bool
                                    if (!ConnectionAvailable(weburl.ToString()))
                                    {
                                        // Console would be getting pretty busy with all
                                        // those threads
                                        Debug.WriteLine(
                                            String.Format(
                                                "{0} was not available",
                                                weburl));
                                    }
                                },
                                rdr[0]);
                    }
                }
            }
        }
    }
    public static bool ConnectionAvailable(string strServer)
    {
        try
        {
            strServer = "http://" + strServer;
            var reqFp = (HttpWebRequest)WebRequest.Create(strServer);
            reqFp.Timeout = 10000;
            reqFp.Method = "HEAD";
            // BTW, what's an "FP"?
            using (var rspFp = (HttpWebResponse) reqFp.GetResponse()) // IDisposable 
            {
                if (HttpStatusCode.OK == rspFp.StatusCode)
                {
                    Debug.WriteLine(string.Format("{0} - OK", strServer));
                    return true; // Dispose called when using is exited
                }
                // Include the error because it's nice to know these things
                Debug.WriteLine(String.Format(
                     "{0} Server returned error: {1}", 
                     strServer, rspFp.StatusCode));
                return false;
            }
        }
        catch (WebException x)
        {
            // Don't tempt fate and don't let programs read human-readable messages
            if (x.Status == WebExceptionStatus.Timeout)
            {
                Debug.WriteLine(string.Format("{0} - Timed out", strServer));
            }
            else
            {
                // The FULL exception, please
                Debug.WriteLine(x.ToString());
            }
            return false;
        }
    }
