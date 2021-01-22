    static void Main(string[] args)
    {
        Console.WriteLine("Running...");
    
        var generator = Observable
            .GenerateWithTime(1, x => x <= 100, x => x, x => TimeSpan.FromMilliseconds(1), x => x + 1)
            .Timestamp();
    
        var bufferedAtOneSec = generator.BufferWithTime(TimeSpan.FromSeconds(1));
    
        var action = new Action<Timestamped<int>>(
            feed => Console.WriteLine("Observed {0:000}, generated at {1}, observed at {2}",
                                      feed.Value,
                                      feed.Timestamp.ToString("mm:ss.fff"),
                                      DateTime.Now.ToString("mm:ss.fff")));
    
        var reactImmediately = true;
        bufferedAtOneSec.Subscribe(list =>
                                       {
                                           if (list.Count == 0)
                                           {
                                               reactImmediately = true;
                                           }
                                           else
                                           {
                                               action(list.Last());
                                           }
                                       });
        generator
            .SkipWhile(item => reactImmediately == false)
            .Subscribe(feed =>
                           {
                               if(reactImmediately)
                               {
                                   reactImmediately = false;
                                   action(feed);
                               }
                           });
    
        Console.ReadKey();
    }
