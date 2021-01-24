    using System;
    using System.Linq;
    using NodaTime;
    using NodaTime.Extensions;
    
    class Test
    {
        static void Main()
        {
            Instant min = Instant.FromUtc(1930, 1, 1, 0, 0, 0);
            Instant max = Instant.FromUtc(2100, 1, 1, 0, 0, 0);
            
            foreach (var zone in DateTimeZoneProviders.Tzdb.GetAllZones())
            {
                var initialStandard = zone.GetZoneInterval(min).StandardOffset;
                var zoneIntervals = zone.GetZoneIntervals(min, max);
                var firstChange = zoneIntervals.FirstOrDefault(zi => zi.StandardOffset != initialStandard);
                if (firstChange != null)
                {
                    Console.WriteLine(zone.Id);
                    Console.WriteLine($"Initial standard offset: {initialStandard}");
                    Console.WriteLine($"First different standard offset: {firstChange}");
                    Console.WriteLine();
                }
            }
        }
    }
