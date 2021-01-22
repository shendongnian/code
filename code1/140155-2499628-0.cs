    public static DateTime Round( DateTime dateTime )
    {
        var updated = dateTime.AddMinutes( 30 );
        return new DateTime( updated.Year, updated.Month, updated.Day,
                             updated.Hour,  0, 0 );
    }
