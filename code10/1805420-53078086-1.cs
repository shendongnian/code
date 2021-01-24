        using System.IO;
        static void Main(string[] args)
        {
            var txtFiles = Directory.EnumerateFiles(@"D:\SampleStackoverflow\", "*.txt");
            foreach (string currentFile in txtFiles)
            {
                var fileStream = new FileStream(currentFile, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //Do the action of Storing the file content
                    }
                } 
            }
        }
