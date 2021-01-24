        public class RealClock : IStubClock
        {
            public DateTime Now
            {
                get
                {
                    return DateTime.Now;
                }
            }
        }
    
