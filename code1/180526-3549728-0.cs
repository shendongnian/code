    try
    {
    Task.WaitAll(someTaskArray, cancelToken)
    }
    catch (OperationCanceledException)
    {
    Task.WaitAll(someTaskArray);
    }
    finally
    {
    for (int i = 0; i < someTaskArray.Length; i++)
    someTaskArray[i].Dispose();
    }
