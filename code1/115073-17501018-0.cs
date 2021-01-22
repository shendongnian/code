    // this will hold parsed value
    DaysOfWeek daySelected;
    
    // 'toMatch' is the string to be parsed or checked
    
    if (Enum.TryParse(toMatch, out daySelected) && Enum.IsDefined(typeof(DaysOfWeek), daySelected))
    {
        // parsed success, use 'daySelected'
    }
    else
    {
        // parsed failed
    }
