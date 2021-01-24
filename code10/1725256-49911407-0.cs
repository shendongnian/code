        class Program
    {
        static void Main(string[] args)
        {
    #if MACOS
            Console.WriteLine("OSX");
    #elif WINDOWS
            Console.WriteLine("Windows");
    #endif
            Console.Read();
        }
