           //  TO get Currrent Time in current Time Zone of your System
            var dt = DateTime.Now;
            Console.WriteLine(dt);
            // Display Time Zone of your System
            Console.WriteLine(TimeZoneInfo.Local);
            // Convert Current Date Time to UTC Date Time
            var utc = TimeZoneInfo.ConvertTimeToUtc(dt, TimeZoneInfo.Local);
            Console.WriteLine(utc);
            // Convert UTC Time to Current Time Zone
            DateTime pacific = TimeZoneInfo.ConvertTimeFromUtc(utc, TimeZoneInfo.Local);
            Console.WriteLine(pacific);
            Console.ReadLine();
