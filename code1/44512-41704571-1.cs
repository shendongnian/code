    using System;
    
    namespace Custom.Extensions
    {
        /// <summary>
        /// Inspired from https://code.msdn.microsoft.com/A-flexible-Default-Value-11c2db19. See usage for more information.
        /// </summary>
        public static class DefaultDateTimeExtensions
        {
            public static DateTime FirstOfYear(this DateTime dateTime)
                => new DateTime(dateTime.Year, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    
            public static DateTime LastOfYear(this DateTime dateTime)
                => new DateTime(dateTime.Year, 12, 31, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    
            public static DateTime FirstOfMonth(this DateTime dateTime)
                => new DateTime(dateTime.Year, dateTime.Month, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    
            public static DateTime LastOfMonth(this DateTime dateTime)
                => new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
        }
    }
