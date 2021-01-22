    private DateTime GetFirstDayOfYearlyQuarter(DateTime value)
    {
        switch (value.Month)
        {
            case 1:
            case 2:
            case 3:
                return new DateTime(value.Year, 1, 1);
            case 4:
            case 5:
            case 6:
                return new DateTime(value.Year, 4, 1);
            case 7:
            case 8:
            case 9:
                return new DateTime(value.Year, 7, 1);
            case 10:
            case 11:
            case 12:
                return new DateTime(value.Year, 10, 1);
            default:
                throw new Exception(@"¯\_(ツ)_/¯");
        }
    }
