    private static void RecurseSome(int number)
    {
        Console.WriteLine(number);
        if (number < 100)
        {
            RecurseSome(++number);
        }
    }
