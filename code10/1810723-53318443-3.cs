    public class FeedHandler
    {
        private readonly IDisposable _subscriber;
        private readonly IObservable<PriceTick> _combinedPriceFeed;
        private readonly List<IObservable<PriceTick>> _feeds = new List<IObservable<PriceTick>>();
        private readonly BehaviorSubject<IObservable<PriceTick>> _combinedPriceFeedChange = new BehaviorSubject<IObservable<PriceTick>>(Observable.Never<PriceTick>());
        private readonly double _throttleFrequency = 1000;
        public FeedHandler()
        {
            _combinedPriceFeed = _combinedPriceFeedChange.Switch().Buffer(TimeSpan.FromMilliseconds(_throttleFrequency)).SelectMany(buffer => buffer.GroupBy(x => x.InstrumentId, (key, result) => result.First()));
            _subscriber = _combinedPriceFeed.Subscribe(NotifyClient);
        }
        public void AddFeed(IObservable<PriceTick> feed)
        {
            _feeds.Add(feed);
            _combinedPriceFeedChange.OnNext(_feeds.Merge());
        }
        public void NotifyClient(PriceTick tick)
        {
            //Do some action
        }
    }
