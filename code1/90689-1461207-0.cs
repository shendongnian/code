    using System;
    using System.IO;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            File.Delete("test.tmp");
            // Prints false - the delete worked
            Console.WriteLine(Directory.GetFiles(".")
                                       .Any(x => x.EndsWith("\\test.tmp")));
            using (Stream stream = File.Create("test.tmp"))
            {
                // Prints true, even though the stream is still open
                Console.WriteLine(Directory.GetFiles(".")
                                           .Any(x => x.EndsWith("\\test.tmp")));
            }       
        }
    }
