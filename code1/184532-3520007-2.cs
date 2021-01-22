    ModesEnum res;
    
    //Implicit generic as opposed to Enum.Parse which returns object
    Enum.TryParse(strPageMode, out res); //returns false if parsing failed
    
    switch (res)
    {
        case ModesEnum.SystemHealth:
            break;
    }
