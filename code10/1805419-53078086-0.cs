        using System.IO;
        static void Main(string[] args)
        {
            var txtFiles = Directory.EnumerateFiles(@"D:\SampleStackoverflow\", "*.txt");
            foreach (string currentFile in txtFiles)
            {
                using (StreamReader sr = File.OpenText(currentFile))
                {
                    string fileContent = sr.ReadToEnd();
                    //Do the action of Storing the file content
                }
            }
        }
