              Random r = new Random();
            var source1 = Observable.Interval(TimeSpan.FromSeconds(1)).Publish().RefCount();
            var source2 = Observable.Interval(TimeSpan.FromMilliseconds(2300)).Select(x => Enumerable.Range(1, 3).Select(y => r.Next(200)).ToObservable()).SelectMany(x => x).Publish().RefCount();
            source1.Subscribe(x => Console.WriteLine("Source1 " + x));
            source2.Subscribe(x => Console.WriteLine("Source2 " + x));
            var merged =source2
                .Buffer(() => source1)
                .Where(l => l.Count > 0)
                .Scan(new { next = 0, remainder = new List<int>() }, (state, val) => new { next = state.remainder.Count > 0 ? state.remainder[0] : val[0], remainder = state.remainder.Concat(val).Skip(1).ToList() })
                .Select(a => a.next);
            merged.Subscribe(x => Console.WriteLine("Merged "+x));
