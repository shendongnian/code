    public void DoStuff<T>(string foo)
    {
        Type type = typeof(T);
        if(type.GetInterfaces().Contains(typeof(IOnline)))
             doStuffOnline<T>(foo);
        else if(type.GetInterfaces().Contains(typeof(IOffline)))
             doStuffOffline<T>(foo);
        else
             throw new Exception("T must implement either IOnline or IOffline");
    }
    
    private void doStuffOnline<T>(string foo){ // can assume T : IOnline }
    private void doStuffOffline<T>(string foo){ // can assume T : IOffline }
