    string RemoveRepeated(string needle, string haystack)
    {
        if (needle == null)
            throw new ArgumentNullException("needle");
        if (haystack == null)
            throw new ArgumentNullException("haystack");
        if (needle == string.Empty || haystack == string.Empty)
            return haystack;
        string doubleNeedle = needle + needle;
        var buffer = new StringBuilder(haystack);
        int originalLength;
        do
        {
            originalLength = buffer.Length;
            buffer.Replace(doubleNeedle, needle);
        } while (originalLength != buffer.Length);
        return buffer.ToString();
    }
