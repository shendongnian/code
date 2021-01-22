    public static class WriteToConsoleExtension
    {
       // Extension to all types
       public static void WriteToConsole(this object instance, 
                                         string format, 
                                         params object[] data)
       {
           Console.WriteLine(format, data);
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            // Usage of extension
            p.WriteToConsole("Test {0}, {1}", DateTime.Now, 1);
        }
    }
