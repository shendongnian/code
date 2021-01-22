    class Program
        {
            static void Main(string[] args)
            {
                string targetFile = System.IO.Path.Combine(@"D://test", "New Text Document.txt");
                string newFileName = "Foo.txt";
    
                // full pattern
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(targetFile);
                fileInfo.Rename(newFileName);
    
                // or short form
                new System.IO.FileInfo(targetFile).Rename(newFileName);
            }
        }
