    bool worked;
    try
    {
        foreach (Item someItem in SomeItems)
        {
            if (someItem.SomeTestFailed()) throw new TestFailedException();
        }
        worked = true;
    }
    catch(TestFailedException testFailedEx)
    {
        worked = false;
    }
    if (worked) // ... logic continues
