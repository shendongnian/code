    using (var source = new SubscribedSubject<long>())
    {
        using (source
            .SubscribeOn(ThreadPoolScheduler.Instance)
            .Subscribe(Console.WriteLine))
        {
            source.OnNext(42);
            Console.ReadKey();
        }
    }
