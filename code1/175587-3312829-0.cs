        private void wee()
        {
            List<List<string>> recordsCollection = new List<List<string>>();
            
            //int idx = 0;
            while(true)
            {
                //scope the batchcollection here if you want to start a thread with an anonymous delegate
                List<string> batchCollection = null;
                // Some code to generate and assign new batchCollection here
                recordsCollection.Add(batchCollection);
                  ThreadPool.QueueUserWorkItem(delegate
                  {
                      ProcessCollection(batchCollection);
                  });
                  //Interlocked.Increment(ref idx);
            }
        }
        private void ProcessCollection(List<string> collection)
        {
            // Do some work on collection here
        }
