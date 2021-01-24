    if (sqlResult is int)
    {
        switch ((int)sqlResult)
        {
           // ...
        }
    }
    else if (sqlResult is string)
    {
        string s = (string)sqlResult;
        // ...
    }
