    public static bool PhoneChecker(string phoneStr)
    {
        if (phoneStr.Length != 16 || phoneStr[0] != '(' || phoneStr[5] != ')' || phoneStr[6] != '-' || phoneStr[11] != ' ')
        {
            return false;
        }
        if (!uint.TryParse(phoneStr.Substring(1, 4), out uint phoneInt))
        {
            return false;
        }
        if (!uint.TryParse(phoneStr.Substring(7, 4), out phoneInt))
        {
            return false;
        }
        // No checks for phoneStr.Substring(12, 4)
        return true;
    }
