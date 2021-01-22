    if (Enum.IsDefined(typeof(ORDER), value))
    {
        switch ((ORDER)Enum.Parse(typeof(ORDER), value)
        {
            case ORDER.partial01:
                // ... 
                break;
            case ORDER.partial12:
                // etc
        }
    }
    else
    {
        // Handle values not in enum here if needed
    }
    
