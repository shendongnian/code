    public static void RecycleApplicationPool(string serverName, string appPoolName)
    {
        if (!string.IsNullOrEmpty(serverName) && !string.IsNullOrEmpty(appPoolName))
        {
            try
            {
                using (ServerManager manager = ServerManager.OpenRemote(serverName))
                {
                    ApplicationPool appPool = manager.ApplicationPools.FirstOrDefault(ap => ap.Name == appPoolName);
                    //Don't bother trying to recycle if we don't have an app pool
                    if (appPool != null)
                    {
                        //Get the current state of the app pool
                        bool appPoolRunning = appPool.State == ObjectState.Started || appPool.State == ObjectState.Starting;
                        bool appPoolStopped = appPool.State == ObjectState.Stopped || appPool.State == ObjectState.Stopping;
                        //The app pool is running, so stop it first.
                        if (appPoolRunning)
                        {
                            //Wait for the app to finish before trying to stop
                            while (appPool.State == ObjectState.Starting) { System.Threading.Thread.Sleep(1000); }
                            //Stop the app if it isn't already stopped
                            if (appPool.State != ObjectState.Stopped)
                            {
                                appPool.Stop();
                            }
                            appPoolStopped = true;
                        }
                        //Only try restart the app pool if it was running in the first place, because there may be a reason it was not started.
                        if (appPoolStopped && appPoolRunning)
                        {
                            //Wait for the app to finish before trying to start
                            while (appPool.State == ObjectState.Stopping) { System.Threading.Thread.Sleep(1000); }
                            //Start the app
                            appPool.Start();
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("An Application Pool does not exist with the name {0}.{1}", serverName, appPoolName));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to restart the application pools for {0}.{1}", serverName, appPoolName), ex.InnerException);
            }
        }
    }
