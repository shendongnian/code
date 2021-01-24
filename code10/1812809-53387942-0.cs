    private CancellationTokenSource _cts; 
    private object syncObj = new Object();
    public void BtnClik1(...)
    {
       lock(syncObj)
       {
          _cts = _cts ?? new CancellationTokenSource();
       } 
       ...
    }
    public void BtnClik2(...)
    {
       lock(syncObj)
       {
           cts?.Cancel();
           cts?.Dispose();
           cts = null; 
       } 
    }
