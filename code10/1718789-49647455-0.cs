     static void Main(string[] args)
            {
                Console.WriteLine("Enter Path");
                var dirPath = @"" + Console.ReadLine();
    
                if (Directory.Exists(dirPath))
                {
                    var path = new DirectoryInfo(dirPath);
                    var files = path.GetFiles();
                }
            }
