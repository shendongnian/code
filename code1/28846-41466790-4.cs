    var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.GB, 2017);
    foreach (var publicHoliday in publicHolidays)
    {
        var name = publicHoliday.LocalName;
    }
