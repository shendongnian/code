    static void Main(string[] args)
    {
        string testValue = "12345“”67890”";
        for (int i = 0; i < 15; i++)
        {
            string cutValue = Program.CutToUTF8Length(testValue, i);
            Console.WriteLine(i.ToString().PadLeft(2) +
                ": " + Encoding.UTF8.GetByteCount(cutValue).ToString().PadLeft(2) +
                ":: " + cutValue);
        }
        Console.WriteLine();
        Console.WriteLine();
        foreach (byte b in Encoding.UTF8.GetBytes(testValue))
        {
            Console.WriteLine(b.ToString().PadLeft(3) + " " + (char)b);
        }
        Console.WriteLine("Return to end.");
        Console.ReadLine();
    }
