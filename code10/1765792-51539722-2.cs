        public class FakeClock : IStubClock
        {
            private DateTime _now;
            public DateTime Now
            {
                get
                {
                    return _now;
                }
            }
    
            public FakeClock(DateTime now)
            {
                _now = now;
            }
        }
