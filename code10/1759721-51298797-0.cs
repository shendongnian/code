    private static readonly TaskFactory _tf = new TaskFactory(
            CancellationToken.None, TaskCreationOptions.None, 
            TaskContinuationOptions.None, TaskScheduler.Default);
    public static TResult RunSync<TResult>(Func<Task<TResult>> func)
    {      
      return _tf.StartNew<Task<TResult>>((Func<Task<TResult>>) (() =>
      {
        return func();
      })).Unwrap<TResult>().GetAwaiter().GetResult();
    }
