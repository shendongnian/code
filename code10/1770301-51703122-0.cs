    byte[] byteArray = Encoding.UTF8.GetBytes(DATA);
    ObjHttpWebRequest.ContentLength = byteArray.Length;
    var cancelSource = new CancellationTokenSource();
    var requestHandlingTask = DoRequestHandling(ObjHttpWebRequest, byteArray, cancelSource.Token);
    if (await Task.WhenAny(requestHandlingTask, Task.Delay(TIMEOUT)) == requestHandlingTask)
    {
        // The task completed inside the timeout
        strReturn = requestHandlingTask.Result;
    }
    else
    {
        // Timeout handling
        cancelSource.Cancel();
        // ...
    }
