    public DateTime ConvertDateTime(DateTime currentDateTime, string sourceTimeZoneId, string destinationTimeZoneId)
    {
        var tzSource = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZoneId);
        var tzDestination = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneId);
        var convertedDateTime = TimeZoneInfo.ConvertTime(currentDateTime, tzSource, tzDestination);
        return convertedDateTime;
    }
