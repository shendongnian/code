    private class ThingeyWrapper
    {
        public Thingey Thing { get; private set; }
      
        private object creationFlag;
    
        public ThingeyWrapper(Request request)
        {
            creationFlag = new object();
    
            ThreadPool.QueueUserWorkItem(() => 
            { 
                lock(creationFlag)
                {
                    Thing = new Thingey(request);
                }
                creationFlag = null;
            }
        }
    
        public void WaitForCreation()
        {
            object flag = creationFlag;
            if(flag != null) lock(flag) { }
        }
    }
