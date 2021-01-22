    public const string LowerCaseAlphabet = "abcdefghijklmnopqrstuvwyxz";
    public const string UpperCaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string GenerateUpperCaseString(int size, Random rng)
    {
        return GenerateString(size, rng, UpperCaseAlphabet);
    }
    public static string GenerateLowerCaseString(int size, Random rng)
    {
        return GenerateString(size, rng, LowerCaseAlphabet);
    }
    public static string GenerateString(int size, Random rng, string alphabet)
    {
        char[] chars = new char[size];
        for (int i=0; i < size; i++)
        {
            chars[i] = alphabet[rng.Next(alphabet.Length)];
        }
        return new string(chars);
    }
