    bool IsDottedDecimalIP(string possibleIP)
    {
        Regex R = New Regex("\b(?:\d{1,3}\.){3}\d{1,3}\b");
        return R.IsMatch(possibleIP) && Net.IPAddress.TryParse(possibleIP, null);
    }
