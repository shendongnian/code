    static void Main(string[] args)
    {
         Console.WriteLine("Console.Out: {0}", IsConsoleOut(Console.Out));
         Console.WriteLine("Other: {0}", IsConsoleOut(new StreamWriter(Stream.Null)));
         Console.ReadLine();
    }
    
    private static bool IsConsoleOut(TextWriter textWriter)
    {
         return object.ReferenceEquals(textWriter, Console.Out);
    }
