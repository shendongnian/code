    var schedule = new HueDateTime()
    {
        When = DateTime.Now + TimeSpan.FromHours(1),
        HowOften = RecurringDay.Monday | RecurringDay.Wednesday
    };
    var succeeded = Enum.TryParse<RecurringDay>("Sunday,Monday,Tuesday", out var when);
