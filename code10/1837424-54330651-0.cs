    foreach (var route in XmlData.ROUTES)
    {
        if (OriginSignal.Equals(route.ENTRANCESIGNAL));
        {
            Console.WriteLine(route.ID);     
        }
    }
