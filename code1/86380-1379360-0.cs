    class myClass
    {
        public void CallingCode()
        {
            ProcessRequest pr1 = new ProcessRequest("storeD","queryObj");
            ThreadStart ts1 = new ThreadStart(pr1.Go);
            Thread wrk = new Thread(ts1);
            wrk.Start();
        }
    }
    
    class ProcessRequest
    {
        private string storeD;
        private string queryObj;
        
        public ProcessRequest(string storeD, string queryObj)
        {
            this.stroreD = storeD;
            this.queryObj = queryObj;
        }
        public void Go()
        {
            try
            {//your processing code here you can access $this->storeD and $this->queryObj
            }
            catch (Exception ex)
            {
            }
        }
    }
