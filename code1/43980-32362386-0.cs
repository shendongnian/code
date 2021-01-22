        private void OnMsgTimer(object sender, ElapsedEventArgs args)
        {
            // mutex creates a single instance in this application
            bool wasMutexCreatedNew = false;
            using(Mutex onlyOne = new Mutex(true, GetMutexName(), out wasMutexCreatedNew))
            {
                if (wasMutexCreatedNew)
                {
                    try
                    {
                          //<your code here>
                    }
                    finally
                    {
                        onlyOne.ReleaseMutex();
                    }
                }
            }
        }
                    
