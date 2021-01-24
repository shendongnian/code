    public static IObservable<string> ReadFileLineByLineAsync(string file)
    {
      return Observable.Create<string>(
        (obs, token) =>
          Task.Factory.StartNew(
            () =>
            {
              using (var s = new StreamReader(file))
              {
                while (!s.EndOfStream)
                  obs.OnNext(s.ReadLine());
              }
              obs.OnCompleted();
            },
            token));
    }
