    using System;
    using System.IO;
    using System.Linq;
    
    public class GetFiles
    {
        public static void Main()
        {
            string[] resultFileNames = (from fileInfo in new DirectoryInfo(@".").GetFiles("????????????.tif") select fileInfo.Name).ToArray();
            foreach(string fileName in resultFileNames)
            {
                Console.WriteLine(fileName);
            }
        }
    }
        
