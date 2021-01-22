    string NormalizeLength(string value, int maxLength)
    {
        //check String.IsNullOrEmpty(value) and act on it. 
        return value.PadRight(maxLength).Substring(0, maxLength);
    }
