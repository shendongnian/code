    TourismItemType tourismType;
    if (Enum.TryParse(NavigationContext.QueryString.Values.First(), out tourismType))
    {
        switch (tourismType)
        {
            case TourismItemType.Destination:
                ShowDestinationInfo();
                break;
            case TourismItemType.PointOfInterest:
                ShowPointOfInterestInfo();
                break;
        }
    }
