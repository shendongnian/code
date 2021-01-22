    static void OutputIntegerStringRepresentations()
    {
        Console.WriteLine("private static string[] integerAsDecimal = new [] {");
        for (int i = int.MinValue; i < int.MaxValue; i++)
        {
            Console.WriteLine("\t\"{0}\",", i);
        }
        Console.WriteLine("\t\"{0}\"", int.MaxValue);
        Console.WriteLine("}");
    }
