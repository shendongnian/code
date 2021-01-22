    while (true)
            {
                // read how long to wait between scans
                // we do this here so that we could, conceivably, update this value while the scanner is running
                int scanwaittime = int.Parse(ConfigurationManager.AppSettings["WaitTime"].ToString());
                if (Engine.IsRunning)
                {
                    // engine is already running another scan - give it some more time
                    System.Threading.Thread.Sleep(scanwaittime);
                }
                else
                {
                    ...
                }
            }
