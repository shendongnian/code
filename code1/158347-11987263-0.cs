    public static DateTime GetDateTimeValue(this PropertyData pd)
    {
        if (pd.Type == CimType.DateTime)
        {
            string format = "yyyyMMddHHmmss.ffffff";
            string val = pd.Value.ToString().Substring(0,format.Length);
            DateTime ret = DateTime.ParseExact(val, format, System.Globalization.CultureInfo.InvariantCulture);
            return ret;
        }
        throw new ArgumentException();
    }
