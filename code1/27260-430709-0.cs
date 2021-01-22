    static void DumpString (string value)
    {
        foreach (char c in value)
        {
            Console.Write ("{0:x4} ", (int)c);
        }
        Console.WriteLine();
    }    
