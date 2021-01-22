    using(var dc = new MyDataContext())
    {
        var results = dc.MyStoredProcedure();
        var returnValue = (int)results.ReturnValue; // note that ReturnValue is of type object and must be cast.
        foreach(var row in results)
        {
            // process row
        }
    }
