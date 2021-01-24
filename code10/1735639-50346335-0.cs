    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                var pattern    = new byte[] { 1, 2, 3, 4, 5 };
                var collection = new [] { pattern, pattern, pattern };
                string filename = @"e:\tmp\test.bin";
                zipToFile(filename, collection);
                var deserialised = unzipFromFile(filename);
                Console.WriteLine(string.Join("\n", deserialised.Select(row => string.Join(", ", row))));
            }
            static void zipToFile(string file, byte[][] data)
            {
                using (var output = new FileStream(file, FileMode.Create))
                using (var gzip   = new GZipStream(output, CompressionLevel.Optimal))
                {
                    new BinaryFormatter().Serialize(gzip, data);
                }
            }
            static byte[][] unzipFromFile(string file)
            {
                using (var input = new FileStream(file, FileMode.Open))
                using (var gzip  = new GZipStream(input, CompressionMode.Decompress))
                {
                    return (byte[][]) new BinaryFormatter().Deserialize(gzip);
                }
            }
        }
    }
