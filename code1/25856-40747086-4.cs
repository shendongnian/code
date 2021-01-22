        static IEnumerable<Trip> CreatePossibleTrips()
        {
            for (int i = 0; i < 1000000; i++)
            {
                yield return new Trip
                {
                    Id = i.ToString(),
                    Driver = new Driver { Id = i.ToString() }
                };
            }
        }
