    int intToCast = 1;
    if (Enum.IsDefined(typeof(TargetEnum), intToCast ))
    {
        TargetEnum target = (TargetEnum)intToCast ;
    }
    else
    {
       // Throw your exception.
    }
