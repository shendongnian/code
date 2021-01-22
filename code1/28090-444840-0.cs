        Dictionary<string, object> downloadLocks = new Dictionary<string, object>();
        void DownloadFile(string localFile, string url)
        {
            object fileLock; 
            lock (downloadLocks)
            {
                if (!downloadLocks.TryGetValue(url, out fileLock))
                {
                    fileLock = new object(); 
                    downloadLocks[url] = fileLock;
                }
            }
            lock (fileLock)
            {
                // check if file is already downloaded 
                // if not then download file
            }
        }
