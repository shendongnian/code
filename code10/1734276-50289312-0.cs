    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NodaTime;
    
    public class Program 
    {
        public static void Main() 
        {
            var start = Instant.FromUtc(2018, 5, 11, 2, 0);
            var end = Instant.FromUtc(2018, 5, 11, 10, 0);
            var input = new Interval(start, end);
            
            DisplayDayIntervals(input, "America/New_York", IsoDayOfWeek.Friday);
            DisplayDayIntervals(input, "Europe/Copenhagen", IsoDayOfWeek.Friday);
        }
                     
        static void DisplayDayIntervals(Interval input, string zoneId, IsoDayOfWeek dayOfWeek)
        {
            var zone = DateTimeZoneProviders.Tzdb[zoneId];
            var intervals = GetDayIntervals(input, zone, dayOfWeek);
            Console.WriteLine($"{zoneId}: [{string.Join(", ", intervals)}]");
        }
                     
        public static IEnumerable<Interval> GetDayIntervals(
            Interval input,
            DateTimeZone zone,
            IsoDayOfWeek dayOfWeek)
        {
            // Get a range of dates that covers the input interval. This is deliberately
            // larger than it may need to be, to handle days starting at different instants
            // in different time zones. 
            LocalDate startDate = input.Start.InZone(DateTimeZone.Utc).Date.PlusDays(-2);
            LocalDate endDate = input.End.InZone(DateTimeZone.Utc).Date.PlusDays(2);        
            var dates = GetDates(startDate, endDate, dayOfWeek);
            
            // Convert those dates into intervals, each of which may or may not overlap
            // with our input.
            var intervals = dates.Select(date => GetIntervalForDate(date, zone));
            
            // Find the intersection of each date-interval with our input, and discard
            // any non-overlaps
            return intervals.Select(dateInterval => Intersect(dateInterval, input))
                            .Where(x => x != null)
                            .Select(x => x.Value);
        }
        
        private static IEnumerable<LocalDate> GetDates(LocalDate start, LocalDate end, IsoDayOfWeek dayOfWeek)
        {
            for (var date = start.With(DateAdjusters.NextOrSame(dayOfWeek));
                 date <= end;
                 date = date.With(DateAdjusters.Next(dayOfWeek)))
             {
                 yield return date;
             }
        }
        
        private static Interval GetIntervalForDate(LocalDate date, DateTimeZone zone)
        {
            var start = date.AtStartOfDayInZone(zone).ToInstant();
            var end = date.PlusDays(1).AtStartOfDayInZone(zone).ToInstant();
            return new Interval(start, end);
        }
        
        private static Interval? Intersect(Interval left, Interval right)
        {
            Instant start = Instant.Max(left.Start, right.Start);
            Instant end = Instant.Min(left.End, right.End);
            return start < end ? new Interval(start, end) : (Interval?) null;
        }
    }
