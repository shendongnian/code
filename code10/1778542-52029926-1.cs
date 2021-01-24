    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            Instant instant = Instant.FromUnixTimeSeconds(1535308200);
            DateTimeZone zone = DateTimeZoneProviders.Tzdb["Europe/Budapest"];
            ZonedDateTime zoned = instant.InZone(zone);
            Console.WriteLine(zoned);
        }
    }
