    DateTime releaseDate;
    try
    {
        // will throw exception if input is not in the default format
        releaseDate = new DateTime(input);
    }
    catch (InvalidFormatException ex)
    {
        releaseDate = GetDateTimeFromNonStandardInput(input);
    }
    catch 
    {
        throw; // or do whatever error handling you feel like.
    }
