    // iterating through a string NO UTF-32 SUPPORT
    for (int i = 0; i < sample.Length; ++i)
    {
        if (Char.IsDigit(sample[i]))
        {
            Console.WriteLine("IsDigit");
        }
        else if (Char.IsLetter(sample[i]))
        {
            Console.WriteLine("IsLetter");
        }
    }
    // iterating through a string WITH UTF-32 SUPPORT
    for (int i = 0; i < sample.Length; ++i)
    {
        if (Char.IsDigit(sample, i))
        {
            Console.WriteLine("IsDigit");
        }
        else if (Char.IsLetter(sample, i))
        {
            Console.WriteLine("IsLetter");
        }
        if (Char.IsSurrogate(sample, i))
        {
            ++i;
        }
    }
