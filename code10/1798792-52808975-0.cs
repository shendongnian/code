    class Caller
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Runner _runner;
        public async Task StartAsync()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                _runner = new Runner();
                await _runner.DoWorkAsync(_cancellationTokenSource.Token);
            }
            catch (OperationCanceledException) when (_cancellationTokenSource.IsCancellationRequested)
            {
                // this will ignore the exception when cancellation is requested. it might be useful in a reset scenario.
                // otherwise, don't try/catch and just let the exception bubble up
            }
            finally
            {
                _runner = null;
                _cancellationTokenSource = null;
            }
        }
        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
    class Runner
    {
        public async Task DoWorkAsync(CancellationToken cancellationToken)
        {
            while(true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(TimeSpan.FromSeconds(30), cancellationToken);
            }
        }
    }
