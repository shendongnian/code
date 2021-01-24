            var xs = new ReplaySubject<Unit>();
            var sxs = Observable.Create<Unit>(async o =>
            {
                await Task.Delay(10);
                o.OnError(new Exception("ERR"));
            }).Subscribe(xs);
            xs.Subscribe(x => Console.WriteLine(x), ex => Console.WriteLine(ex.Message));
            xs.Subscribe(x => Console.WriteLine(x), ex => Console.WriteLine(ex.Message));
            xs.DefaultIfEmpty().Wait();
            Console.WriteLine("-end-");
            Console.ReadLine();
