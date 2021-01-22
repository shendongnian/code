    public class IdGenerator
    {
        private Queue<string> mIds = new Queue<string>();
        private BackgroundWorker mWorker = new BackgroundWorker();
        private static EventWaitHandle mWaitHandle = new AutoResetEvent(false);
    
        public IdGenerator()
        {
            GenerateIds();
    
            this.mWorker.DoWork += new DoWorkEventHandler(FillQueueWithIds);
        }
    
        private void GenerateIds()
        {
            List<string> ids = new List<string>();
    
            for (int i = 0; i < 100; i++ )
            {
                ids.Add(Guid.NewGuid().ToString());
            }
    
            lock (this.mIds)
            {
    
                foreach (string id in ids)
                {
                    this.mIds.Enqueue(id);
                } 
            }            
        }
    
        public string GetId()
        {
            string id = string.Empty;
            //Indicates if we need to wait
            bool needWait = false;
            do
            {
                lock (this.mIds)
                 {
                    if (this.mIds.Count > 0)
                    {
                        id = this.mIds.Dequeue();
                        return id;
                    }
    
                    if (this.mIds.Count < 100 && this.mIds.Count > 0)
                    {
                        if (!this.mWorker.IsBusy)
                        {
                            this.mWorker.RunWorkerAsync();
                        }
                    } 
                    else 
                    {
                        needWait = true;
                    }
                }
    
                if (needWait)
                {
                    mWaitHandle.WaitOne();
                    needWait = false;
                }
            } while(true);
    
            return id;
        }
    
        void FillQueueWithIds(object sender, DoWorkEventArgs e)
        {
            GenerateIds();
            mWaitHandle.Set();   
        }
    }
