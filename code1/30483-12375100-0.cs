    string culture = "en-GB";
    CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
    for (int i = 0; i < 10000; i++)
    {
        try
        {
            CultureInfo c = new CultureInfo(culture);
        }
        catch
        {
        }
    }
    for (int i = 0; i < 10000; i++)
    {
        CultureInfo c = cultures.FirstOrDefault((x) => x.Name == culture);
    }
    for (int i = 0; i < 10000; i++)
    {
        foreach (CultureInfo c in cultures)
        {
            if (c.Name == culture)
                break;
        }
    }
