    if (!String.IsNullOrEmpty(testString)
        && testString.All(c => Char.IsLetterOrDigit(c) && (c < 128)))
    {
        // Alphanumeric.
    }
