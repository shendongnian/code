    public static class TaskExtensions
    {
        public static TReturn ParallelSelectReturnFastest<TPoolObject, TReturn>(this TPoolObject[] pool,
            Func<TPoolObject, CancellationToken, TReturn> func, 
            int? timeout = null)
        {
            var ctx = new CancellationTokenSource();
    
            // for every object in pool schedule a task
            Task<TReturn>[] tasks = pool
                .Select(poolObject =>
                {
                    ctx.Token.ThrowIfCancellationRequested();
                    return Task.Factory.StartNew(() => func(poolObject, ctx.Token), ctx.Token);
                })
                .ToArray();
    
           // not sure if Cast is actually needed, 
           // just to get rid of co-variant array conversion
           int firstCompletedIndex = timeout.HasValue
                ? Task.WaitAny(tasks.Cast<Task>().ToArray(), timeout.Value, ctx.Token)
                : Task.WaitAny(tasks.Cast<Task>().ToArray(), ctx.Token);
    			
            // we need to cancel token to avoid unnecessary work to be done
    		ctx.Cancel();
    
            if (firstCompletedIndex == -1) // no objects in pool managed to complete action in time
                throw new NotImplementedException(); // custom exception goes here
    
            return tasks[firstCompletedIndex].Result;
        }
    }
