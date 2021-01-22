    public static TEnum ParseEnum<TEnum>(string valueString, string parameterName = null)
    {
        var parsed = (TEnum)Enum.Parse(typeof(TEnum), valueString, true);
        decimal d;
        if (!decimal.TryParse(parsed.ToString(), out d))
        {
            return parsed;
        }
        if (!string.IsNullOrEmpty(parameterName))
        {
            throw new ArgumentException(string.Format("Bad parameter value. Name: {0}, value: {1}", parameterName, valueString), parameterName);
        }
        else
        {
            throw new ArgumentException("Bad value. Value: " + valueString);
        }
    }
