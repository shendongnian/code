    void BeginTimedMyMethod(...)
    {
        //create delegate with StartMethod as target
        //Invoke StartMethod delegate
    }
    void StartTimedMethod(Request request)
    {
        stopWatches[i].Start();
        webservice.MyMethod(request);
    }
