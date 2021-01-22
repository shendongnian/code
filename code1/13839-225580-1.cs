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
            //replace newLineDelim with newLineDelim + a new line
            //trim to get rid of any new lines chars at the end of the file
            string filetext = text.Replace(newLineDelim, newLineDelim + Environment.NewLine).Trim();
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(filename)))
            {
                sw.Write(filetext);
            }
        }
    }
