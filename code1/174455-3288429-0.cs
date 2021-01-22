        System.Threading.ThreadPool.QueueUserWorkItem(
            (o) =>
            {
                bool loop = true;
                while (loop)
                    if (sync.WaitOne())
                        lock (filesLocker)
                        {
                            if (files < maxFiles)
                            {
                                ++files;
                                if (files == maxFiles)
                                    sync.Reset();
                                loop = false;
                            }
                        }
            });
    //Have the try catch OUTSIDE the background thread.
                try
                {
                    WebClient downloadClient = new WebClient();
                    downloadClient.OpenReadCompleted += new OpenReadCompletedEventHandler(downloadClient_OpenReadCompleted);
                    downloadClient.OpenReadAsync(new Uri(url, UriKind.Absolute));
                    //5 of them do get here
                }
                catch
                {
                    lock (filesLocker)
                    {
                        --files;
                        sync.Set();
                    }
                    throw;
                }
