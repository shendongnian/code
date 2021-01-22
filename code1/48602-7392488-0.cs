    var task = Task.Factory.StartNew(state => action(), state);
    task.ContinueWith(t => 
         {
            var exception = t.Exception.InnerException;
            // handle the exception here
            // (note that we access InnerException, because tasks always wrap
            // exceptions in an AggregateException)
         }, 
         TaskContinuationOptions.OnlyOnFaulted);
