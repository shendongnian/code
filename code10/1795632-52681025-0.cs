    public Boolean SetDate(int Month, int Day, int Year)
    {
        Boolean valid = true;
        // here you validate the date, and assign value of validation to "valid" variable
        StartDate = valid ? new Date(Year, Month, Day) : new Date(1900, 1, 1);
        return valid;
    }
