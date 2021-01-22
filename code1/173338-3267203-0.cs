    internal IEnumerable<InterestingObject> FindInterestingObjects() 
    { 
        /* etc */ 
    }
    public void LongRunningMethod()
    {
        foreach (var obj in FindInterestingObjects())
        {
            OnInterestingEvent(obj);
        }
    }
