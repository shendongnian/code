    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace FakeDateTime
    {
        class Hotel
        {
            public DateTime ClosingTime = DateTime.ParseExact("17:00:00", "HH:ii:ss", CultureInfo.InvariantCulture);
            public IStubClock Clock;
            public bool IsOpen
            {
                get
                {
                    return Clock.Now.TimeOfDay <= ClosingTime.TimeOfDay;
                }
            }
            public Hotel(IStubClock clock)
            {
                Clock = clock;
            }
        }
    
        public interface IStubClock
        {
            DateTime Now { get; }
        }
    
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
    
        class Program
        {
            static void Main(string[] args)
            {
                IStubClock fakeClock = new FakeClock(new DateTime(1, 1, 1, 10, 0, 0)); //time is set to 10am
                IStubClock realClock = new RealClock(); //time is set to whatever the time now is.
                Hotel hotel1 = new Hotel(fakeClock); //using fake time
                Hotel hotel2 = new Hotel(realClock); //using the real time
            }
        }
    }
