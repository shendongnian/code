    public string LowerCaseAlphabet = "abcdefghijklmnopqrstuvwyxz";
    public string UpperCaseAlphabet = LowerCaseAlphabet.ToUpperCase(CultureInfo.InvariantCulture);
    public static string GenerateString(int size, Random rng, string alphabet)
    {
        char[] chars = new char[size];
        for (int i=0; i < size; i++)
        {
            chars[i] = alphabet[rng.Next(alphabet.Length)];
        }
        return new string(chars);
    }
