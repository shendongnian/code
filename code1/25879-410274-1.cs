    Generic.Dictionary<int, int> dic = new Generic.Dictionary<int, int>();
    lock (((IDictionary)dic).SyncRoot)
    {
        // code
    }
