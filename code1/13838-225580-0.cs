    using System;
    using System.IO;
    static class Program
    {
        static void Main()
        {
            WriteToFile
            (
            @"C:\test.txt",
            "fkdfdsfdflkdkfk@dfsdfjk72388389@kdkfkdfkkl@jkdjkfjd@jjjk@",
            "@"
            );
            /*
            output in test.txt in windows =
            fkdfdsfdflkdkfk@
            dfsdfjk72388389@
            kdkfkdfkkl@
            jkdjkfjd@
            jjjk@ 
            */
        }
        public static void WriteToFile(string filename, string text, string newLineDelim)
        {
            bool equal = Environment.NewLine == "\r\n";
            //Environment.NewLine == \r\n = True
            Console.WriteLine("Environment.NewLine == \\r\\n = {0}", equal);
            string filetext = text.Replace(newLineDelim, newLineDelim + Environment.NewLine);
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(filename)))
            {
                sw.Write(filetext);
            }
        }
    }
