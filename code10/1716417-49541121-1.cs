    class Program
        {
            static void Main(string[] args)
            {
                //Declaring variables for use later
                List<string> directories = new List<string>();
                List<FileInfo> fileList = new List<FileInfo>();
    
    
                //Load Directories from XML
                XElement Options = XElement.Load(@"C:\Directories.xml");
                IEnumerable<XElement> DirList =
                    from dir in Options.Descendants("Directory")
                    select dir;
                foreach (XElement dirName in DirList)
                {
                    directories.Add((string)dirName);
                }
    
    
                //Converting XML strings to Directories and adding all subfolders over 30 seconds old to a delete list
                foreach (var directory in directories)
                {
                    DirectoryInfo dirItem = new DirectoryInfo(directory);
                    var folderList = dirItem.GetDirectories();
                    Console.WriteLine(folderList);
                }
            }
        }   
