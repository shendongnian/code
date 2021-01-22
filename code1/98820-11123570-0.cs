    static IEnumerable<int> getNums()
    {
        Console.WriteLine("IENUM - ENTER");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
            yield return i;
        }
        Console.WriteLine("IENUM - EXIT");
    }
    static IEnumerable<int> getNums2()
    {
        try
        {
            Console.WriteLine("IENUM - ENTER");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                yield return i;
            }
        }
        finally
        {
            Console.WriteLine("IENUM - EXIT");
        }
    }
