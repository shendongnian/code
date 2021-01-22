    Dictionary<string, ThingeyWrapper> thingeys = new Dictionary<string, ThingeyWrapper>();
    
    private class ThingeyWrapper
    {
        public Thingey Thing { get; private set; }
      
        private object creationLock;
        private Request request;
    
        public ThingeyWrapper(Request request)
        {
            creationFlag = new object();
            this.request = request;
        }
    
        public void WaitForCreation()
        {
            object flag = creationFlag;
            if(flag != null)
            {
                lock(flag)
                {
                    if(request != null) Thing = new Thingey(request);
                    creationFlag = null;
                    request = null;
                }
            }
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
