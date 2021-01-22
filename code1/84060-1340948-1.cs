    string RemoveRepeated(string needle, string haystack)
    {
        string doubleNeedle = needle + needle;
        while (haystack.IndexOf(doubleNeedle) >= 0)
            haystack = haystack.Replace(doubleNeedle, needle);
        return haystack;
    }
