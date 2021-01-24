    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            var buffer = new byte[3];
            var stream = new MemoryStream(buffer);
            stream.WriteByte(1);
            stream.WriteByte(2);
            stream.WriteByte(3);
            Console.WriteLine("Three successful writes");
            stream.WriteByte(4); // This throws
            Console.WriteLine("Four successful writes??");
        }
    }
