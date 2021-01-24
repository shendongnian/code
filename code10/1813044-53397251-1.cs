    public class TimeSpanBuilder
    {
        private TimeSpan _ts = TimeSpan.Zero;
        public TimeSpanBuilder WithHours(double hours)
        {
            _ts = _ts.Add(TimeSpan.FromHours(hours));
            return this;
        }
        public TimeSpanBuilder WithMinutes(double mins)
        {
            _ts = _ts.Add(TimeSpan.FromMinutes(mins));
            return this;
        }
        public TimeSpanBuilder WithSeconds(double seconds)
        {
            _ts = _ts.Add(TimeSpan.FromMinutes(seconds));
            return this;
        }
        public TimeSpan Build()
        {
            return _ts;
        }
    }
