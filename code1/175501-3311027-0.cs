    // This should be in it's own function; I am just too lazy to spell out a signature.
    {
        if (res == ResultType.Failure)
        {
            return ProcessFailure(..);
        }
        if (res == ResultType.ScheduledAndMonitored)
        {
            bool result = DoSomething(...);
            result = result && DoSomething3(..);
            return result;
        }
        if (res == ResultType.MoreInfoAvailable)
        { 
             info = GetInfo(..);
             // Ok, and then?
        }
        if (res == ResultType.OK && someCondition)
        { 
            return DoSomething2(..);
        }
        // Else ...
        Debug.Assert(false, "Why did we get here? Explanation: ");
    }
