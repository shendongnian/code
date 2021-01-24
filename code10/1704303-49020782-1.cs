    public class ParallelInvokesMultipleInvocationsAndThrowsOneException //names are hard
    {
        public void InvokeActions(params Action[] actions)
        {
            using (CancellationTokenSource source = new CancellationTokenSource())
            {
                // The invocations can put their exceptions here.
                var exceptions = new ConcurrentQueue<Exception>();
                var wrappedActions = actions
                    .Select(action => new Action(() =>
                        InvokeAndCancelOthersOnException(action, source, exceptions)))
                    .ToArray();
                try
                {
                    Parallel.Invoke(new ParallelOptions{CancellationToken = source.Token}, 
                        wrappedActions)
                }
                // if any of the invocations throw an exception, 
                // the parallel invocation will get canceled and 
                // throw an OperationCanceledException;
                catch (OperationCanceledException ex)
                {
                    Exception invocationException;
                    if (exceptions.TryDequeue(out invocationException))
                    {
                        //rethrow however you wish.
                        throw new Exception(ex.Message, invocationException);
                    }
                    // You shouldn't reach this point, but if you do, throw something else.
                    // In the unlikely but possible event that you get more
                    // than one exception, you'll lose all but one.
                }
            }
        }
        private void InvokeAndCancelOthersOnException(Action action,
            CancellationTokenSource cancellationTokenSource,
            ConcurrentQueue<Exception> exceptions)
        {
            // Try to invoke the action. If it throws an exception,
            // capture the exception and then cancel the entire Parallel.Invoke.
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
                cancellationTokenSource.Cancel();
            }
        }
    }
