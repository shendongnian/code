    foreach (MonthEnum month in Enum.GetValues(typeof(MonthEnum)))
    {
        double hoursToWork;
        double hoursWorked;
        string enumName = Enum.GetName(typeof(MonthEnum), month);
        bool x = double.TryParse(model.data[0].GetType().GetField(enumName).GetValue(model.data[0]).ToString(), out hoursToWork);
        bool y = double.TryParse(model.data[0].GetType().GetField(enumName).GetValue(model.data[1]).ToString(), out hoursWorked);
        // If either of the TryParse fails, don't create a model due to false Data
        if(!x || !y) continue;
        HrsAccount acc = new HrsAccount
        {
            AccountId = new Guid(),
            UserId = loggedInUser,
            Month = (int)month,
            HoursToWork = hoursToWork,
            HoursWorked = hoursWorked
        };
    }
