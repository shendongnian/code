    public class FeedHandler
    {
        private readonly IDisposable _subscriber;
        private readonly SourceList<IObservable<PriceTick>> _feeds = new SourceList<IObservable<PriceTick>>();
        private readonly double _throttleFrequency = 1000;
        public FeedHandler()
        {
            var combinedPriceFeed = _feeds.Connect().MergeMany(x => x).Buffer(TimeSpan.FromMilliseconds(_throttleFrequency)).SelectMany(buffer => buffer.GroupBy(x => x.InstrumentId, (key, result) => result.First()));
            _subscriber = combinedPriceFeed.Subscribe(NotifyClient);
        }
        public void AddFeed(IObservable<PriceTick> feed) => _feeds.Add(feed);
        public void NotifyClient(PriceTick tick)
        {
            //Do some action
        }
    }
