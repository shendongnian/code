    private static Subject<MyObject> subject = new Subject<MyObject>();
    private static IDisposable subscription = subject
        .Throttle (TimeSpan.FromMilliseconds (100))
        .Subscribe(v =>
            {
                // Some code here
            });
    
    private static void MethodToCall(MyObject v)
    {
        subject.OnNext(v);
    }
