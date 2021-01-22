    List<Char> printableChars = new List<char>();
    for (int i = char.MinValue; i <= char.MaxValue; i++)
    {
        char c = Convert.ToChar(i);
        if (!char.IsControl(c))
        {
            printableChars.Add(c);
        }
    }
