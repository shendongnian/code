using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string large = LargeJsonContent.GetBigObject();
            string base64;
            using (var readStream = new MemoryStream())
            using (var writeStream = new MemoryStream())
            {
                using (GZipStream compressor = new GZipStream(writeStream, CompressionMode.Compress, true)) //pay attention to leaveOpen = true
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(readStream, large);
                    Console.WriteLine($"After binary serialization of JsonString: {readStream.Length} bytes");
                    readStream.Position = 0;
                    readStream.CopyTo(compressor);
                }
                Console.WriteLine($"Compressed stream size: {writeStream.Length} bytes");
                writeStream.Position = 0;
                byte[] writeBytes = writeStream.ToArray();
                base64 = Convert.ToBase64String(writeBytes);
            }
           
            ////
            
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, base64);
                Console.WriteLine($"Size of base64: {stream.Length} bytes");
            }
            Console.WriteLine("---------------------");
            ////
            string large2;
            var bytes = Convert.FromBase64String(base64);
            using (var readStream = new MemoryStream())
            {
                readStream.Write(bytes, 0, bytes.Length);
                readStream.Position = 0;
                Console.WriteLine($"Compressed stream size: {readStream.Length} bytes");
                using (var writeStream = new MemoryStream())
                {
                    using (GZipStream decompressor = new GZipStream(readStream, CompressionMode.Decompress, true)) //pay attention to leaveOpen = true
                    {
                        decompressor.CopyTo(writeStream);
                        writeStream.Position = 0;
                    }
                    var formatter = new BinaryFormatter();
                    large2 = (string)formatter.Deserialize(writeStream);
                }
            }
            Console.WriteLine(large == large2);
            Console.WriteLine($"large:{large.Length} | large2:{large2.Length}");
        }
    }
}
