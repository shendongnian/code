             // Insert this where check is required, in my case program start
             ThreadPool.QueueUserWorkItem(CheckInternetConnectivity);
        }
        void CheckInternetConnectivity(object state)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                    webClient.Proxy = null;
                    webClient.OpenReadCompleted += webClient_OpenReadCompleted;
                    webClient.OpenReadAsync(new Uri("<url of choice here>"));
                }
            }
        }
        volatile bool internetAvailable = false; // boolean used elsewhere in code
        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                internetAvailable = true;
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    // UI changes made here
                }));
            }
        }
    
