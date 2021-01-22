    ModesEnum res;
    
    Enum.TryParse(strPageMode, out res); //Implicit generic parsing, returns false if parsing failed
    
    switch (res)
    {
        case ModesEnum.SystemHealth:
            break;
    }
