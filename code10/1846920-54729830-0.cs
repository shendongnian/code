    int monthInput = 1;
    int dayInput = 23;
    
    try
    {
        var myDate = new DateTime(DateTime.Now.Year, monthInput, dayInput);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        //monthInput is less than 1 or greater than 12.
        //- or -
        //dayInput is less than 1 or greater than the number of days in month.
        Console.WriteLine(ex);
        throw;
    }
    Console.WriteLine($"{myDate}")
