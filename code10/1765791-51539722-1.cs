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
