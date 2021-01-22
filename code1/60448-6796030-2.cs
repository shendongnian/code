    // Fake Day of Week
    string strDOWFake = "SuperDay";
    // Real Day of Week
    string strDOWReal = "Friday";
    // Will hold which ever is the real DOW.
    DayOfWeek enmDOW;
    // See if fake DOW is defined in the DayOfWeek enumeration.
    if (Enum.IsDefined(typeof(DayOfWeek), strDOWFake))
    {
        // This will never be reached since "SuperDay"
        // doesn't exist in the DayOfWeek enumeration.
        enmDOW = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), strDOWFake);
    }
    // See if real DOW is defined in the DayOfWeek enumeration.
    else if (Enum.IsDefined(typeof(DayOfWeek), strDOWReal))
    {
        // This will parse the string into it's corresponding DOW enum object.
        enmDOW = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), strDOWReal);
    }
    // Can now use the DOW enum object.
    Console.Write("Today is " + enmDOW.ToString() + ".");
