    using System;
    namespace NewLineThingy
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "fkdfdsfdflkdkfk@dfsdfjk72388389@kdkfkdfkkl@jkdjkfjd@jjjk@";
                str = str.Replace("@", "@" + Environment.NewLine);
                Console.WriteLine(str);
                Console.ReadKey();
            }
        }
    }
