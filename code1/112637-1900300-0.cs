    [WebMethod]
    public string NewBusiness(string myParam)
    {
        if (InDisasterMode())
        {
            // Only if you actually need this...
            HttpContext context = HttpContext.Current;
            // Thread the standard method call
            ThreadPool.QueueUserWorkItem(delegate
            {
                HttpContext.Current = context;
                ProcessNewBusiness(myParam);
            });
            return 'ok';
        }
        else
        {
            // Call standard method synchronously to get result
            return ProcessNewBusiness(myParam);
        }
    }
