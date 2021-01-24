    public class Message
    {
        public string Payload { get; set; }
        public int Size { get; set; }
    }
    public static IObservable<IList<Message>> BufferWithThrottle(this IObservable<Message> source,
                                                         TimeSpan threshold, int maxSize)
    {
        return Observable.Create<IList<Message>>((obs) =>
        {
            return source.GroupByUntil(_ => true,
                                       g => g.Throttle(threshold).Select(_ => Unit.Default)
                                             .Merge(g.Select( i => i.Size)
                                                     .Scan(0, (a, b) => a + b)
                                                     .Where(a => a >= maxSize)
                                                     .Select(_ => Unit.Default)))
                         .SelectMany(i => i.ToList())
                         .Subscribe(obs);
        });
    }
