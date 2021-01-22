    static public class DateTimeFunctions
    {
        static public DateTimeOffset ConvertUtcTimeToTimeZone(this DateTime dateTime, string toTimeZoneDesc)
        {
            if (dateTime.Kind != DateTimeKind.Utc) throw new Exception("dateTime needs to have Kind property set to Utc");
            var toUtcOffset = TimeZoneInfo.FindSystemTimeZoneById(toTimeZoneDesc).GetUtcOffset(dateTime);
            var convertedTime = DateTime.SpecifyKind(dateTime.Add(toUtcOffset), DateTimeKind.Unspecified);
            return new DateTimeOffset(convertedTime, toUtcOffset);
        }
    }
