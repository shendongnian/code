    var tcs = new TaskCompletionSource<object>();
    var th = new Thread(() => MockCicloDeVida(tcs));
    th.Start();
    try
    {
        var returnedObj = tcs.Task.Result;
    }
    catch(AggregateException aex)
    {
        Console.WriteLine(aex.InnerExceptions.First().Message);
    }
----
    public void MockCicloDeVida(TaskCompletionSource<object> tcs )
    {
        Thread.Sleep(10000);
        tcs.TrySetException(new Exception("something bad happened"));
        //tcs.TrySetResult(new SomeObject());
    }
