    public static class DisposeHelper
    {
      public static TDisposable DisposeOnError<TDisposable>(TDisposable dispoable, Action<TDisposable> action)
         where TDisposable : IDisposable
      {
        try
        {
           action(dispoable);
        }
        catch(Exception)
        {
           disposable.Dispose();
           throw;
        }
        return disposable;
      }
    }
