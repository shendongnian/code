    using System;
    using System.Linq;
    using NodaTime;
    using NodaTime.Extensions;
    
    class Test
    {
        static void Main()
        {
            // No FromMinutes method for some reason...
            var target = Offset.FromSeconds(330 * 60);
            var now = SystemClock.Instance.GetCurrentInstant();
            var zones = DateTimeZoneProviders.Tzdb.GetAllZones()
                .Where(zone => zone.GetUtcOffset(now) == target);
            foreach (var zone in zones)
            {
                Console.WriteLine(zone.Id);
            }
        }
    }
