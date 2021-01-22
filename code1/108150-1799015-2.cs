    Dictionary<string, ThingeyWrapper> thingeys = new Dictionary<string, ThingeyWrapper>();
    
    private class ThingeyWrapper
    {
        public Thingey Thing { get; private set; }
      
        private AutoResetEvent creationFlag;
    
        public ThingeyWrapper(Request request)
        {
            creationFlag = new AutoResetEvent(false);
    
            ThreadPool.QueueUserWorkItem(() => 
            { 
                Thing = new Thingey(request);
    
                creationFlag.Set();
    
                creationFlag = null;
            }
        }
    
        public void WaitForCreation()
        {
            AutoResetEvent evt = creationFlag;
    
            if(evt != null) evt.WaitOne();
        }
    }
    
    public Thingey GetThingey(Request request)
    {
        string thingeyName = request.ThingeyName;
    
        ThingeyWrapper output;
    
        lock (this.Thingeys)
        {
            if(!this.Thingeys.TryGetValue(thingeyName, out output))
            {
                output = new ThingeyWrapper(request);
    
                this.Thingeys.Add(thingeyName, output);
            }
        }
        
        output.WaitForCreation();
    
        return output.Thing;
    }
