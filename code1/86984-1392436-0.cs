    using System;
    
    class Test
    {
        static void Main()
        {
            var mountainView = TimeZoneInfo.FindSystemTimeZoneById
                ("Pacific Standard Time");
            var london = TimeZoneInfo.FindSystemTimeZoneById
                ("GMT Standard Time");
            DateTimeOffset now = DateTimeOffset.UtcNow;
            
            TimeSpan mountainViewOffset = mountainView.GetUtcOffset(now);
            TimeSpan londonOffset = london.GetUtcOffset(now);
            
            Console.WriteLine(londonOffset-mountainViewOffset); // 8 hours
        }
    }
