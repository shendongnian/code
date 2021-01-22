    public class Timestamped
    {
        private readonly ITimestampProvider _timestampProvider;
    
        public Timestamped(ITimestampProvider timestampProvider)
        {
            _timestampProvider = timestampProvider;
        }
        
        public Timestamped(): this(new SystemTimestampProvider())
        { }
    }
    
