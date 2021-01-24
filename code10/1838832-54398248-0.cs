    public static class DateTimeHelpers
      {
        public static DateTime ConvertToUTC(DateTime dateTimeToConvert, string sourceZoneIdentifier)
        {
          TimeZoneInfo sourceTZ = TimeZoneInfo.FindSystemTimeZoneById(sourceZoneIdentifier);
          TimeZoneInfo destinationTZ = TimeZoneInfo.FindSystemTimeZoneById("UTC");
    
          return TimeZoneInfo.ConvertTime(dateTimeToConvert, sourceTZ, destinationTZ);
        }
    
        public static DateTime ConvertToTimezone(DateTime utcDateTime, string destinationZoneIdentifier)
        {
          TimeZoneInfo sourceTZ = TimeZoneInfo.FindSystemTimeZoneById("UTC");
          TimeZoneInfo destinazionTZ = TimeZoneInfo.FindSystemTimeZoneById(destinationZoneIdentifier);
    
          return DateTime.SpecifyKind(TimeZoneInfo.ConvertTime(utcDateTime, sourceTZ, destinazionTZ), DateTimeKind.Local);
        }
    
        public static DateTime GetCurrentDateTimeInZone(string destinationZoneIdentifier)
        {
          TimeZoneInfo sourceTZ = TimeZoneInfo.FindSystemTimeZoneById("UTC");
          TimeZoneInfo destinazionTZ = TimeZoneInfo.FindSystemTimeZoneById(destinationZoneIdentifier);
    
          return DateTime.SpecifyKind(TimeZoneInfo.ConvertTime(DateTime.UtcNow, sourceTZ, destinazionTZ), DateTimeKind.Local);
        }
      }
