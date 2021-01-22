    public char GenerateChar(Random rng)
    {
        // 'Z' + 1 because the range is exclusive
        return (char) (rng.Next('A', 'Z' + 1));
    }
    public string GenerateString(Random rng, int length)
    { 
        char[] letters = new char[length];
        for (int i = 0; i < length; i++)
        {
            letters[i] = GenerateChar(rng);
        }
        return new string(letters);
    }
