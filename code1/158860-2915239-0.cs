    using System;
    using System.IO;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            byte[] withBom = { 0xef, 0xbb, 0xbf, 0x41 };
            string viaEncoding = Encoding.UTF8.GetString(withBom);
            Console.WriteLine(viaEncoding.Length);
            
            string viaStreamReader;
            using (StreamReader reader = new StreamReader
                   (new MemoryStream(withBom), Encoding.UTF8))
            {
                viaStreamReader = reader.ReadToEnd();           
            }
            Console.WriteLine(viaStreamReader.Length);
        }
    }
