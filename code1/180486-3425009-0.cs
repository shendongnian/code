    Timer serviceTimer = new Timer();
        void startTimer()
        {
            serviceTimer.Interval = 60;
            serviceTimer.Elapsed += new ElapsedEventHandler(serviceTimer_Elapsed);
            serviceTimer.AutoReset = false;
            serviceTimer.Start();
        }
        void serviceTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Get your rows of queued work requests
                // Now Push Each Row to Background Thread Processing
                foreach (Row aRow in RowsOfRequests)
                {
                    ThreadPool.QueueUserWorkItem(
                        new WaitCallback(longWorkingCode), 
                        aRow);
                }
            }
            finally
            {
                // Wait Another 60 Seconds and check again
                serviceTimer.Stop();
            }
        }
        void longWorkingCode(object workObject)
        {
            Row workRow = workObject as Row;
            if (workRow == null)
                return;
            // Do your Long work here on workRow
        }
