    public static int UncheckedAddition(int a, int b)
    {
        unchecked { return a + b; }
    }
    public static int CheckedAddition(int a, int b)
    {
        checked { return a + b; } // or "return checked(a + b)";
    }
    public static void Main() 
    {
        Console.WriteLine("Unchecked: " + UncheckedAddition(Int32.MaxValue, + 1));  // "Wraps around"
        Console.WriteLine("Checked: " + CheckedAddition(Int32.MaxValue, + 1));  // Throws an Overflow exception
        Console.ReadLine();
    }
