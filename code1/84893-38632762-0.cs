    System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
    string _pos = dblstr.Replace(".",
        ci.NumberFormat.NumberDecimalSeparator).Replace(",",
            ci.NumberFormat.NumberDecimalSeparator);
    double _dbl = double.Parse(_pos);
