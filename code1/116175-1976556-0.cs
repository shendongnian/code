    private static IList<String> _links = new List<String>();
    private const int NumberOfThreads = 2;
        
    public void SpawnWebRequests()
    {
        IList<Thread> threadList = new List<Thread>();
        
        for (int i = 0; i < NumberOfThreads; i++)
        {
            var thread = new Thread(ProcessWebRequests);
            threadList.Add(thread);
            thread.Start();
        }
        
        for (int i = 0; i < NumberOfThreads; i++)
        {
            threadList[i].Join();
        }
    }
    
    private static void ProcessWebRequests()
    {
        while (true)
        {
            lock(_links)
            {
                if (_links.Count == 0)
                    break;
    
                String link = _links.RemoveAt(0);
            }
    
            ProcessWebRequest(link);
        }
    }
    
    private static void ProcessWebRequest(String link)
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(link);
            request.Method = "HEAD"; // or "GET", since some sites (Amazon) don't allow HEAD
            request.Timeout = DefaultTimeoutSeconds * 1000;
    
            // Get the response (throws an exception if status != 200)
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                    Log.Debug("Working link: {0}", request.RequestUri);
            }
        }
        catch (WebException ex)
        {
            var response = ((HttpWebResponse)ex.Response);
            var status = response != null
                             ? response.StatusCode
                             : HttpStatusCode.RequestTimeout;
    
            Log.WarnException(String.Format("Broken link ({0}): {1}", status, link), ex);
            
            // Don't rethrow, as this is an expected exception in many cases
        }
        catch (Exception ex)
        {
            Log.ErrorException(String.Format("Error processing link {0}", link), ex);
            
            // Rethrow, something went wrong
            throw;
        }
    }
