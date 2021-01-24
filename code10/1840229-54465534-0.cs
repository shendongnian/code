    using System;
    using System.IO;
    using System.IO.Compression;
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            private static readonly string outPutFileName = @"C:<my desktop directory>\gergrgr.gzip";
            
            public static void Compress(string inPath)
            {
                using (var inputStream = new FileStream(inPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var outputStream = new FileStream(outPutFileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (var gzip = new GZipStream(outputStream, CompressionMode.Compress))
                        {
                            inputStream.CopyTo(gzip);
                        }
                    }
                }
            }
            
            private static void Main(string[] args)
            {
                // info info info....
                Console.WriteLine("Drag in txt file");
    
                // Takes the path from dragged in file
                var filePath = Console.ReadLine();
                if (!string.IsNullOrEmpty(filePath))
                {
                    Compress(filePath.Trim('\\', '"'));
                }
            }
        }
    }
