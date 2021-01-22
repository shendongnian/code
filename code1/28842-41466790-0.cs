    var publicHolidays = DateSystem.GetPublicHoliday("UK", 2017);
    foreach (var publicHoliday in publicHolidays)
    {
        var name = publicHoliday.LocalName;
    }
