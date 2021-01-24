      static void Main(string[] args)
        {
            Random r = new Random();
            var source1 = Observable.Interval(TimeSpan.FromSeconds(1)).Publish().RefCount();
            var source2 = Observable.Interval(TimeSpan.FromMilliseconds(7000)).Select(x => Enumerable.Range(1, 3).Select(y => r.Next(200)).ToObservable()).SelectMany(x => x).Publish().RefCount();
            source1.Subscribe(x => Console.WriteLine("Source1 " + x));
            source2.Subscribe(x => Console.WriteLine("Source2 " + x));
            
            //THIS BIT
             Subject<int> queue = new Subject<int>();
            source2.Subscribe(queue);
            var merged=queue
                .Buffer(() => source1)
                .Do(l => { foreach (var n in l.Skip(l.Count > 1 ? 1 : 0)) queue.OnNext(n); })
                .Where(l=>l.Count > 0)
                .Select(l => l.First());
                merged.Subscribe(x => Console.WriteLine("Merged "+x));
          
            
        
            Console.ReadKey();
          
        }
