    static int GetClosestNumber(int value, int step)
    {
        var lower = value / step * step;
        return value - lower < step / 2 ? lower : lower + step;
    }
    static void Main()
    {
        Console.WriteLine(GetClosestNumber(1038, 5));
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
