    TResult CreateUsingDisposable<TDisposable, TResult>(TDisposable disposable, Func<TDisposable, TResult> getResult)
      where TDisposable : IDisposable
    {
      using (disposable)
      {
        return getResult(disposable);
      }
    }
    
    using (var obj = CreateUsingDisposable(new FileStream(path, FileMode.Open), stream => new MyObject(stream)))
    {
    }
