    static int GetAge(LocalDate dateOfBirth)
    {
        Instant now = SystemClock.Instance.Now;
            
        // The target time zone is important.
        // It should align with the *current physical location* of the person
        // you are talking about.  When the whereabouts of that person are unknown,
        // then you use the time zone of the person who is *asking* for the age.
        // The time zone of birth is irrelevant!
        DateTimeZone zone = DateTimeZoneProviders.Tzdb["America/New_York"];
        LocalDate today = now.InZone(zone).Date;
        Period period = Period.Between(dateOfBirth, today, PeriodUnits.Years);
        return (int) period.Years;
    }
