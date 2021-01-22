    public static double GetDouble(string value, double defaultValue)
    {
        double result;
    
        //Try parsing in the current culture
        if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
            //Then try in US english
            !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
            //Then in neutral language
            !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
        {
            result = defaultValue;
        }
    
        return result;
    }
