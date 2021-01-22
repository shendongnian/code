    System.Collections.Generic.Dictionary<int, int> dic = new Dictionary<int, int>();
    lock (((IDictionary)dic).SyncRoot)
    {
        // code
    }
