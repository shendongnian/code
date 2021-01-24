    public static void PrintNumber(int num)
    {
        Console.WriteLine(num);
    }
    public static void Function(Action<int> predicate, int param)
    {
        predicate(param);
    }
    Function(PrintNumber,5);
