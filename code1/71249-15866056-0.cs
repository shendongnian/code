    static string
        numbers = "0123456789",
        letters = "abcdefghijklmnopqrstvwxyz",
        lettersUp = letters.ToUpper(),
        codeAll = numbers + letters + lettersUp;
    static Random m_rand = new Random();
    public static string GenerateCode(this int size)
    {
        return size.GenerateCode(CodeGeneratorType.All);
    }
    public static string GenerateCode(this int size, CodeGeneratorType type)
    {
        string source;
        
        if (type == CodeGeneratorType.All)
        {
            source = codeAll;
        }
        else
        {
            StringBuilder sourceBuilder = new StringBuilder();
            if ((type & CodeGeneratorType.Letters) == CodeGeneratorType.Numbers)
                sourceBuilder.Append(numbers);
            if ((type & CodeGeneratorType.Letters) == CodeGeneratorType.Letters)
                sourceBuilder.Append(letters);
            if ((type & CodeGeneratorType.Letters) == CodeGeneratorType.LettersUpperCase)
                sourceBuilder.Append(lettersUp);
            source = sourceBuilder.ToString();
        }
        return size.GenerateCode(source);
    }
    public static string GenerateCode(this int size, string source)
    {
        StringBuilder code = new StringBuilder();
        int maxIndex = source.Length-1;
        for (int i = 0; i < size; i++)
        {
            code.Append(source[Convert.ToInt32(Math.Round(m_rand.NextDouble() * maxIndex))]);
        }
        return code.ToString();
    }
    public enum CodeGeneratorType { Numbers = 1, Letters = 2, LettersUpperCase = 4, All = 16 };
