    public struct DateTimeWithZone
    {
        private readonly DateTime utcDateTime;
        private readonly TimeZoneInfo timeZone;
        public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
        {
            var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone); 
            this.timeZone = timeZone;
        }
        public DateTime UniversalTime { get { return utcDateTime; } }
        public TimeZoneInfo TimeZone { get { return timeZone; } }
        public DateTime LocalTime
        { 
            get 
            { 
                return TimeZoneInfo.ConvertTime(utcDateTime, timeZone); 
            }
        }        
    }
