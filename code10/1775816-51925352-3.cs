    [MemoryDiagnoser]
    public class CancelBench
    {
        private int delayValue = 15;
        private CancellationToken cancellationToken = new CancellationToken(true);
        [Benchmark]
        public async Task<bool> Exception()
        {
            try
            {
                await Task.Delay(delayValue, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                // token triggered cancellation
                return true;
            }
            return false;
        }
        [Benchmark]
        public async Task<bool> ContinueWith()
        {
            var task = await Task.Delay(delayValue, cancellationToken).ContinueWith(t => t);
            if (task.IsCanceled)
            {
                // token triggered cancellation
                return true;
            }
            return false;
        }
    }
