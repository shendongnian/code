    // Input values (as per the question)
    var timeStr = "03:22";
    var dateStr = "2018/01/12";
    var format = "yyyy/MM/dd";
    var timeZone = "Asia/Tehran";
    // The patterns we'll use to parse input values
    LocalTimePattern timePattern = LocalTimePattern.CreateWithInvariantCulture("HH:mm");
    LocalDatePattern datePattern = LocalDatePattern.CreateWithInvariantCulture(format);
    // The local parts, parsed with the patterns and then combined.
    // Note that this will throw an exception if the values can't be parsed -
    // use the ParseResult<T> return from Parse to check for success before
    // using Value if you want to avoid throwing.
    LocalTime localTime = timePattern.Parse(timeStr).Value;
    LocalDate localDate = datePattern.Parse(dateStr).Value;
    LocalDateTime localDateTime = localDate + localTime;
    // Now get the time zone by ID
    DateTimeZone zone = DateTimeZoneProviders.Tzdb[timeZone];
    // Work out the zoned date/time being represented by the local date/time. See below for the "leniently" part.
    ZonedDateTime zonedDateTime = localDateTime.InZoneLeniently(zone);
    // The Noda Time type you want would be OffsetDateTime
    OffsetDateTime offsetDateTime = zonedDateTime.ToOffsetDateTime();
    // If you really want the BCL type...
    DateTimeOffset dateTimeOffset = zonedDateTime.ToDateTimeOffset();
