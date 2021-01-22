    using System;
    using System.Text;
    using System.IO;
    
    class Test    
    {
        static void Main()
        {
            Encoding enc = new UTF8Encoding(false); // Prints 1 1
            // Encoding enc = Encoding.UTF8; // Prints 1 4
            string content = "x";
            Console.WriteLine(enc.GetByteCount("x"));
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, enc);
            sw.Write(content);
            sw.Flush();
            Console.WriteLine(ms.Length);
        }
        
    }
