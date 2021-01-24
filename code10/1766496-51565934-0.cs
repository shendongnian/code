    class Thing
    {
        public int Value { get; set; }
    }
    abstract class ThingFactory
    {
        public abstract Thing GetOrCreate(string key);
    }
    class ThingManager
    {
        private readonly ConditionalWeakTable<Thing, object> _locks;
        private readonly ThingFactory _factory;
        public ThingManager(ThingFactory factory)
        {
            _factory = factory;
            _locks = new ConditionalWeakTable<Thing, object>();
        }
        public int Increment(string key,  int incr)
        {
            var thing = _factory.GetOrCreate(key);
            var thingLock = _locks.GetOrCreateValue(thing);
            lock (thingLock)
            {
                int newValue = thing.Value + incr;
                thing.Value = newValue;
                return newValue;
            }
        }
    }
