    public static long AddRequest() 
    {
        return Interlocked.Increment (ref _totalOutstandingRequests);
    }
    public static long RemoveRequest() 
    {
        return Interlocked.Decrement (ref _totalOutstandingRequests);
    }
    public static long GetRequests() 
    {
        return _totalOutstandingRequests;
    }
