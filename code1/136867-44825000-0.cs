    public class ThingThatNeedsTimeProvider
    {
        private readonly Func<DateTimeOffset> now;
        private int nextId;
        public ThingThatNeedsTimeProvider(Func<DateTimeOffset> now)
        {
            this.now = now;
            this.nextId = 1;
        }
        public (int Id, DateTimeOffset CreatedAt) MakeIllustratingTuple()
        {
            return (nextId++, now());
        }
    }
