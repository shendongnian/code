    static readonly char[] Digits = "0123456789".ToCharArray();
    ...
    string noSpaces = original.Replace(" ", "");
    int lastDigit = noSpaces.LastIndexOfAny(Digits);
    if (lastDigit == -1)
    {
        throw new ArgumentException("No digits!");
    }
    string normalized = noSpaces.Insert(lastDigit, " ");
                               
