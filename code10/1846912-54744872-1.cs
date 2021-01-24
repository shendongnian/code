    private static char OneVowelToSymbol(char c)
    {
        switch (c)
        {
            case 'A': case 'E': case 'I': case 'O': case 'U':
            case 'a': case 'e': case 'i': case 'o': case 'u':
                return '$';
            default:
                return c;
        }
    }
    public static string VowelsToSymbolLinq(string input)
    {
        return string.IsNullOrWhiteSpace(input) ? input :
            new string(input.Select(OneVowelToSymbol).ToArray());
    }
