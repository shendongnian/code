    public static bool TryParse(string value, out bool result)
    {
        result = false;
        if (value != null)
        {
            if ("True".Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                result = true;
                return true;
            }
            if ("False".Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                result = false;
                return true;
            }
            if (m_trimmableChars == null)
            {
                char[] destinationArray = new char[string.WhitespaceChars.Length + 1];
                Array.Copy(string.WhitespaceChars, destinationArray, string.WhitespaceChars.Length);
                destinationArray[destinationArray.Length - 1] = '\0';
                m_trimmableChars = destinationArray;
            }
            value = value.Trim(m_trimmableChars);
            if ("True".Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                result = true;
                return true;
            }
            if ("False".Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                result = false;
                return true;
            }
        }
        return false;
    }
 
