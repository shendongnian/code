    int tourismType;
    if ( int.TryParse(NavigationContext.QueryString.Values.First(), out tourismType )
    {
        if ( Enum.IsDefined(typeof(TourismItemType), tourismType) )
        {
            switch ((TourismItemType)tourismType)
            {
                ...
            }
        }
        else
        {
            // tourismType not a valid TourismItemType
        }
    }
    else
    {
        // NavigationContext.QueryString.Values.First() not a valid int
    }
