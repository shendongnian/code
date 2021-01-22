    public bool ParseString(string maybeBool)
    {
        return ParseString(maybeBool, false);
    }
    public bool ParseString(string maybeBool, bool default)
    {
        bool stringBool;
        if (bool.TryParse(maybeBool, out stringBool))
            return stringBool;
        if (string.Equals(maybeBool, "T", StringComparison.OrdinalIgnoreCase))
            return true;
        if (string.Equals(maybeBool, "F", StringComparison.OrdinalIgnoreCase))
            return false;
        return default;
    }
