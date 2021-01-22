    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            foreach (var file in new DirectoryInfo(".").GetFiles("200810*"))
            {
                Console.WriteLine(file);
            }
        }
    }
