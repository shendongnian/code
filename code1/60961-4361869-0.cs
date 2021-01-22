    string[] version_names = rk.GetSubKeyNames();
    //version names start with 'v', eg, 'v3.5'
    //we also need to take care of strings like v2.0.50727...
    string sCurrent = version_names[version_names.Length - 1].Remove(0, 1);
    if (sCurrent.LastIndexOf(".") > 1)
    {
    	string[] sSplit = sCurrent.Split('.');
    	sCurrent = sSplit[0] + "." + sSplit[1] + sSplit[2];
    }
    double dCurrent = Convert.ToDouble(sCurrent, System.Globalization.CultureInfo.InvariantCulture);
    double dExpected = Convert.ToDouble(ci.Version);
    if (dCurrent >= dExpected)
