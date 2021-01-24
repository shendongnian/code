    public static class RxHelpers
    {
        public static IObservable<TInput2> RegulatedQueue<TInput1, TInput2>(this IObservable<TInput2> input2,
           IObservable<TInput1> input1
            )
        {
            return Observable.Using(() => new Subject<TInput2>(),
            queue =>
            {
                input2.Subscribe(queue);
                return queue
                    .Buffer(() => input1)
                    .Do(l => { foreach (var n in l.Skip(l.Count > 1 ? 1 : 0)) queue.OnNext(n); })
                    .Where(l => l.Count > 0)
                    .Select(l => l.First()).
                    Publish().
                    RefCount();
            });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            var source1 = Observable.Interval(TimeSpan.FromSeconds(1)).Publish().RefCount();
            var source2 = Observable.Interval(TimeSpan.FromMilliseconds(2000)).Select(x => Enumerable.Range(1, 3).Select(y => r.Next(200)).ToObservable()).SelectMany(x => x).Publish().RefCount();
            source1.Subscribe(x => Console.WriteLine("Source1 " + x));
            source2.Subscribe(x => Console.WriteLine("Source2 " + x));
            var merged = source2.RegulatedQueue(source1);
            merged.Subscribe(x => Console.WriteLine("Merged1 " + x));
            merged.Subscribe(x => Console.WriteLine("Merged2 " + x));
            Console.ReadKey();
        }
    }
