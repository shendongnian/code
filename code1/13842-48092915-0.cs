    using System;
    using System.IO;
    using System.Text;
    
    class Test
    {
        public static void Main()
        {
                 string strToProcess = "fkdfdsfdflkdkfk@dfsdfjk72388389@kdkfkdfkkl@jkdjkfjd@jjjk@";
                strToProcess.Replace("@", Environment.NewLine);
                Console.WriteLine(strToProcess);
        }
    }
