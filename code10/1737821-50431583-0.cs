    public void CheckAll(List<SomeClass> spans)
    {
        var chinaTZ = TimeZoneInfo.CreateCustomTimeZone(zoneID, TimeSpan.Parse("-08:00"), displayName, standardName);
        var nowInChina = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, chinaTZ);
        foreach ( var span in spans )
        {
            if (InRange(nowInChina, span.startDay, span.endDay))
                // Do something on success 
                // Check for valid times here
                ;
            else
                // Do something on Failure
                ;
        }
    }
    public bool InRange(DateTime dateToCheck, DayOfWeek startDay, DayOfWeek endDay)
    {
        // Initialise as one day prior because first action in loop is to increment current
        var current = (int)startDay - 1;
        do
        {
            // Move to next day, wrap back to Sunday if went past Saturday
            current = (current + 1) % 7;
            if (dateToCheck.DayOfWeek == (DayOfWeek)current)
                return true;
        } while (current != (int)endDay);
        return false;
    }
