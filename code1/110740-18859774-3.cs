    using System;
    using System.IO;
    using System.IO.Compression;
    
    namespace DataCompressor
    {
        class Program
        {
            //This program is used to compress the compiled VssAgent for storage in the snapshot program
            static void Main(string[] args)
            {
                //Will quit directly if any args are invalid.
                ValidateArgs(args);
    
                using (var sourceFile = File.OpenRead(args[0]))
                using (var destFile = new FileStream(args[1], FileMode.Create))
                using (var gz = new GZipStream(destFile, CompressionMode.Compress))
                {
                    sourceFile.CopyTo(gz);
                }
            }
    
            private static void ValidateArgs(string[] args)
            {
                if (args.Length == 2)
                {
                    if (File.Exists(args[0]) == false)
                    {
                        Console.Error.WriteLine("The source file did not exist.");
                        Environment.Exit(-2);
                    }
                    if (Directory.Exists(Path.GetDirectoryName(args[1])) == false)
                    {
                        Console.Error.WriteLine("The destination directory did not exist.");
                        Environment.Exit(-3);
                    }
                }
                else
                {
                    Console.Error.WriteLine("You must pass two arguments.");
                    Environment.Exit(-1);
                }
            }
        }
    }
