    public void ProcessDelegates(IList<Action> thingsToDo, int maxConcurrency)
    {
        int currentConcurrency = 0;        
        IList<WaitHandle> resultHandles = new List<WaitHandle>();
        foreach (var thingToDo in thingsToDo)
        {
            var asyncResult = thingToDo.BeginInvoke();
            resultHandles.Add(asyncResult.AsyncWaitHandle);
    
            if (++currentConcurrency >= maxConcurrency)
            {
                WaitHandle.WaitAny(resultHandles.ToArray());
                --currentConcurrency;
            }
        }
    }
