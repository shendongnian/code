    public static bool TryParseBoolean(this string value, out bool result)
    {
        if (value == "yes")
        {
            result = true;
            return true;
        }
        else if (value == "no")
        {
            result = false;
            return true;
        }
        else
        {
            return bool.TryParse(value, out result);
        }
    }
