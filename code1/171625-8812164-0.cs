         static void Main(string[] args)
            {
                Console.WriteLine("Start");
                var debugDir = Environment.CurrentDirectory;
                DirectoryInfo di = new DirectoryInfo(debugDir);               
                var searchDir = "";
                while (!di.FullName.ToLower().EndsWith("Folder1"))
                {
                    if(di.FullName.ToLower().EndsWith(":")) //if you went too far up as in "D:" then
                       break;
                    di = di.Parent;
                }
    
               Console.WriteLine(di.FullName);
    }
