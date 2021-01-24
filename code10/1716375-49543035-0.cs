    public class ProducerConsumerQueue
    {
        private readonly BlockingCollection<Action> queue = new BlockingCollection<Action>();
        public Task Produce(Action work)
        {
            var tcs = new TaskCompletionSource<bool>();
            Action action = () =>
            {
                try
                {
                    work();
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            };
            queue.Add(action);
            return tcs.Task;
        }
        public void RunConsumer(CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                var action = queue.Take(token);
                action();
            }
        }
    }
