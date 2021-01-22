    static void Rec(int i)
    {
        Console.WriteLine(i);
        if (i < int.MaxValue)
        {
            Rec(i + 1);
        }
    }
