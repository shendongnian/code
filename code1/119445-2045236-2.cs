    public static void Main(string[] args)
    {
      Console.WriteLine(AdjustPath("3123~101", @"3123|X:directory\Path\Directory|Pre0{0442-0500}.txt"));
      Console.WriteLine(AdjustPath("3123~101", @"3123|X:directory\Path\Directory|0{0442-0500}.txt"));
    }
