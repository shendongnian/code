    public async Task<T> WaitForActionCompletionOrTimeout<T>(Func<T> action, int timeOut)
    {
         var result = default(T);
         var cancellationTokenSource = new CancellationTokenSource();
         Task timeoutTask = null;
         Task actionTask = null;
         var mre = new ManualResetEvent(false);
         try
         {
            timeoutTask = Task.Delay(timeout, cancellationTokenSource.Token);
            actionTask = Task.Factory.StartNew(() =>
                {
                  result = action.Invoke();
                }, cancellationTokenSource.Token);
        }
        catch (Exception ex)
        {
           Trace.WriteLine(ex.Message);
        }
        finally
        {
           await Task.WhenAny(actionTask, timeoutTask).ContinueWith(t =>
               {
                   cancellationTokenSource.Cancel();
                   mre.Set();
               });
        }
        mre.WaitOne();
        return result;
    }
