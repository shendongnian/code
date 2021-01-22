    using System;
    using System.IO;
    
    class DeDuper
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: DeDuper <input file> <output file>");
                return;
            }
            using (TextReader reader = File.OpenText(args[0]))
            using (TextWriter writer = File.CreateText(args[1]))
            {
                string currentLine;
                string lastLine = null;
                
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (currentLine != lastLine)
                    {
                        writer.WriteLine(currentLine);
                        lastLine = currentLine;
                    }
                }
            }
        }
    }
