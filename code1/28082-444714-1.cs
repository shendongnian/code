    try
    {
        for(int i = 0; i < n; ++i)
        {
            myCall(i);
        }
    }catch(SomeException se)
    {
        Log("Something terrible happened during the %ith iteration.", se.Iteration);
    }
