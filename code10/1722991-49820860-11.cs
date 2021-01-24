    private static void Main()
    {
        var bigNumber = int.MaxValue;
        Console.WriteLine(bigNumber.ToString());
        Console.WriteLine(bigNumber.ToCustomString());
        Console.WriteLine(bigNumber.ToCustomString(2, "-"));
        Console.WriteLine(bigNumber.ToCustomString(5, " < *_* > "));
        GetKeyFromUser("\nDone!! Press any key to exit...");
    }
