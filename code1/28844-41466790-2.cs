    var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.UK, 2017);
    foreach (var publicHoliday in publicHolidays)
    {
        var name = publicHoliday.LocalName;
    }
