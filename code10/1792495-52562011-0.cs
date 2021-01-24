    public class CancellableSemaphoreSlim
    {
        CancellationTokenSource cancelSource = new CancellationTokenSource();
        readonly SemaphoreSlim ss;
    
        public CancellableSemaphoreSlim(int initialCount) 
        { 
            ss = new SemaphoreSlim(initialCount); 
        }
    
        public Task WaitAsync() => ss.WaitAsync(cancelSource.Token);
    
        public Task WaitAsync(CancellationToken cancellationToken)
        {
            // This operation will cancel when either the user token or our cancelSource signal cancellation
            CancellationTokenSource linkedSource =  CancellationTokenSource.CreateLinkedTokenSource(cancelSource.Token, cancellationToken);
            return ss.WaitAsync(linkedSource.Token);
        }
    
        public int Release() => ss.Release();
    
        public void CancelAll()
        {
            var currentCancelSource = Interlocked.Exchange(ref cancelSource, new CancellationTokenSource());
            currentCancelSource.Cancel();
        }
    }
