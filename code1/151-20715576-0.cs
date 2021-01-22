    static int GetAge(LocalDate dateOfBirth)
    {
        Instant now = SystemClock.Instance.Now;
            
        // This uses the local time zone, but you might want a different one.
        // It usually aligns with the location of the person who is *asking* for
        // the age, not the person whose age you are calculating.
        DateTimeZone zone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
        LocalDate today = now.InZone(zone).Date;
        Period period = Period.Between(dateOfBirth, today, PeriodUnits.Years);
        return (int) period.Years;
    }
