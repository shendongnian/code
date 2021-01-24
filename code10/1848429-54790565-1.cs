    if(DateTime.TryParse(ts,CultureInfo.GetCultureInfo("en-US"),DateTimeStyles.None,out var dt))
    {
        Console.WriteLine(dt);
    }
    else
    {
        //Parsing failed!
    }
    
