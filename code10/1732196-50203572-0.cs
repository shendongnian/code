    public static void Test(int i)
    {
        Console.WriteLine("Test()");
    }
    public static int GetNumber()
    {
        return 5;
    }
    Test(GetNumber());
