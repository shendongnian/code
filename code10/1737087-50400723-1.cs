            Random r = new Random();
            var source1 = Observable.Interval(TimeSpan.FromSeconds(1)).Publish().RefCount();
            var source2 = Observable.Interval(TimeSpan.FromMilliseconds(7000)).Select(x => Enumerable.Range(1, 3).Select(y => r.Next(200)).ToObservable()).SelectMany(x => x).Publish().RefCount();
            source1.Subscribe(x => Console.WriteLine("Source1 " + x));
            source2.Subscribe(x => Console.WriteLine("Source2 " + x));
            var merged =
                source2.Select(s2 => Tuple.Create(2, s2))
                .Merge(source1.Select(s1 => Tuple.Create(1, (int)s1)))
                .Scan(Tuple.Create((int?)null, new Queue<int>(),0), (state, val) =>
                     {
                         int? next = state.Item1;
                         if (val.Item1 == 1)
                         {
                             if (state.Item2.Count > 0)
                             {
                                 next = state.Item2.Dequeue();
                             }
                         }
                         else
                         {
                             state.Item2.Enqueue(val.Item2);
                         }
                         return Tuple.Create(next, state.Item2,val.Item1);
                     })
                .Where(x=>(x.Item1!=null && x.Item3==1))
                .Select(x => x.Item1);
                
                
            merged.Subscribe(x => Console.WriteLine("Merged "+x));
