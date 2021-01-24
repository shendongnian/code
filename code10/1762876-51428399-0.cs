    double[] Parse(string s)
    {
        var valueStrings = s.Split(new string[] { " ", "°C" }, 
            System.StringSplitOptions.RemoveEmptyEntries);
        return valueStrings.Select(xs => System.Double.Parse(xs)).ToArray();
    }
