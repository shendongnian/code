    public string TypeAway(int size)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        
        for (int i = 0; i < size; i++)
        {
            ch = legalCharacters[random.Next(0, legalCharacters.Length)];
            builder.Append(ch);
        }
        return builder.ToString();
    }
