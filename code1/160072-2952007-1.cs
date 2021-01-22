    public delegate AsyncUpdateNumber GetAsyncUpdateNumber(object state, int value);
    [WebMethod]
    public IAsyncResult BeginFetchNumber(AsyncCallback cb, object state) 
    {
        int value = Database.GetNumber();
        AsyncUpdateNumber async = new AsyncUpdateNumber(value);
        GetAsyncUpdateNumber getAsyncUpdateNumber = new GetAsyncUpdateNumber(async.DoLongRunningThing);
        return getAsyncUpdateNumber.BeginInvoke(state, cb, getAsyncUpdateNumber);
    }
    [WebMethod]
    public int EndFetchNumber(IAsyncResult res) 
    {
        GetAsyncUpdateNumber getAsyncUpdateNumber = (GetAsyncUpdateNumber)res.AsyncState;
        return getAsyncUpdateNumber.EndInvoke(res);
    }
