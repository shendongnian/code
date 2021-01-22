    public static IObservable<Sample<T>> SampleResponsive<T>(this IObservable<T> source, TimeSpan interval, IScheduler scheduler = null) {
      if (source == null)
        throw new ArgumentNullException(nameof(source));
      return Observable.Create<Sample<T>>(
        observer => {
          var gate = new Object();
          var lastSampleValue = default(T);
          var lastSampleTime = default(DateTime);
          var sampleCount = 0;
          var scheduledTask = new SerialDisposable();
          return new CompositeDisposable(
            source.Subscribe(
              value => {
                lock (gate) {
                  var now = DateTime.UtcNow;
                  var elapsed = now - lastSampleTime;
                  if (elapsed >= interval) {
                    observer.OnNext(new Sample<T>(value, 1));
                    lastSampleValue = value;
                    lastSampleTime = now;
                    sampleCount = 0;
                  }
                  else {
                    if (scheduledTask.Disposable == null) {
                      scheduledTask.Disposable = (scheduler ?? Scheduler.Default).Schedule(
                        interval - elapsed,
                        () => {
                          lock (gate) {
                            if (sampleCount > 0) {
                              lastSampleTime = DateTime.UtcNow;
                              observer.OnNext(new Sample<T>(lastSampleValue, sampleCount));
                              sampleCount = 0;
                            }
                            scheduledTask.Disposable = null;
                          }
                        }
                      );
                    }
                    lastSampleValue = value;
                    sampleCount += 1;
                  }
                }
              },
              error => {
                if (sampleCount > 0)
                  observer.OnNext(new Sample<T>(lastSampleValue, sampleCount));
                observer.OnError(error);
              },
              () => {
                if (sampleCount > 0)
                  observer.OnNext(new Sample<T>(lastSampleValue, sampleCount));
                observer.OnCompleted();
              }
            ),
            scheduledTask
          );
        }
      );
    }
