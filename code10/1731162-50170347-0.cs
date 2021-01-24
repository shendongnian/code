    public class MyClass
    {
        static void Main()
        {
    #if NET40
            Console.WriteLine("Target framework: .NET Framework 4.0");
    #elif NET45  
            Console.WriteLine("Target framework: .NET Framework 4.5");
    #else
            Console.WriteLine("Target framework: .NET Standard 1.4");
    #endif
        }
    }
