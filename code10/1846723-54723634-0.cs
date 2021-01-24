    using (var source = new Subject<long>())
    {
        var connectableSource = source.Replay();
        connectableSource.Connect();
        using (var subscription = connectableSource
                        .SubscribeOn(ThreadPoolScheduler.Instance)
                        .Subscribe(Console.WriteLine))
        {
            source.OnNext(42); // outputs 42 always
            Console.ReadKey(false);
        }
    }
