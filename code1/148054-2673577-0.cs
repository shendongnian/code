    Action foo = () =>
    {
        Thread.Sleep(1000);
    };
    var handles = new List<WaitHandle>();
    for (int i = 0; i < 10; i++)
    {
        var result = foo.BeginInvoke(r =>
        {
            foo.EndInvoke(r);
        }, null);
        handles.Add(result.AsyncWaitHandle);
    }
    WaitHandle.WaitAll(handles.ToArray());
