    int day, month, year;
    if (Int32.TryParse(dayInput.Value, out day)) {
        if (Int32.TryParse(monthInput.Value, out month)) {
            if (Int32.TryParse(yearInput.Value, out year)) {
                DateTime birthDate = new DateTime(year, month, day);
                if ([birthDate is in valid range])
                    // it passes
            }
        }
    }
