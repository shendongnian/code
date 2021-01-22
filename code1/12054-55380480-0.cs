    int i;
    bool b = int.TryParse( "123-",
               System.Globalization.NumberStyles.AllowTrailingSign,
               System.Globalization.CultureInfo.InvariantCulture,
               out i);
