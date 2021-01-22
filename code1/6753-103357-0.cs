    /// <summary>The regular expression parser used to parse the lat/long</summary>
    private static Regex Parser = new Regex("^(?<deg>[-+0-9]+)[^0-9]+(?<min>[0-9]+)[^0-9]+(?<sec>[0-9.,]+)[^0-9.,ENSW]+(?<pos>[ENSW]*)$");
    /// <summary>Parses the lat lon value.</summary>
    /// <param name="value">The value.</param>
    /// <remarks>It must have at leasr 3 parts 'degrees' 'minutes' 'seconds'. If it 
    /// has E/W and N/S this is used to change the sign.</remarks>
    /// <returns></returns>
    public static double ParseLatLonValue(string value)
    {
        // If it starts and finishes with a quote, strip them off
        if (value.StartsWith("\"") && value.EndsWith("\""))
        {
            value = value.Substring(1, value.Length - 2).Replace("\"\"", "\"");
        }
        // Now parse using the regex parser
        Match match = Parser.Match(value);
        if (!match.Success)
        {
            throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, "Lat/long value of '{0}' is not recognised", value));
        }
        // Convert - adjust the sign if necessary
        double deg = double.Parse(match.Groups["deg"].Value);
        double min = double.Parse(match.Groups["min"].Value);
        double sec = double.Parse(match.Groups["sec"].Value);
        double result = deg + (min / 60) + (sec / 3600);
        if (match.Groups["pos"].Success)
        {
            char ch = match.Groups["pos"].Value[0];
            result = ((ch == 'S') || (ch == 'W')) ? -result : result;
        }
        return result;
    }
