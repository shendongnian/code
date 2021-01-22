    double val;
    if(double.TryParse("65,89875", System.Globalization.NumberStyles.Float, GermanCulture,  out val))
    {
        string valInGermanFormat = val.ToString(GermanCulture);
        string valInEnglishFormat = val.ToString(EnglishCulture);
    }
    if(double.TryParse("65.89875", System.Globalization.NumberStyles.Float, EnglishCulture,  out val))
    {
        string valInGermanFormat = val.ToString(GermanCulture);
        string valInEnglishFormat = val.ToString(EnglishCulture);
    }
    
