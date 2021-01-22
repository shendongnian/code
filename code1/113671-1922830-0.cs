    public class CheckForFile
        {
            private Dictionary<String, List<String>> FileDirectoryList;
            private String StartLocation;
            private String Format;
    
            public CheckForFile(String StartLocation, String Format)
            {
                this.FileDirectoryList = new Dictionary<string, List<string>>();
                this.StartLocation = StartLocation;
                this.Format = Format;
            }
    
            public void Discover()
            {
                DirectoryInfo di = new DirectoryInfo(this.StartLocation);
                DirectoryInfo[] ChildDirectoryList = di.GetDirectories("*", SearchOption.AllDirectories);
                
                foreach(DirectoryInfo ChildDir in ChildDirectoryList)
                {
                    Console.WriteLine(ChildDir.FullName);
                    FileInfo[] FileInfoList = ChildDir.GetFiles(this.Format);
    
                    this.FileDirectoryList.Add(ChildDir.FullName, new List<string>());
    
                    foreach (FileInfo ChildFileInfo in FileInfoList)
                    {
                        Console.WriteLine("\t\t" + ChildFileInfo.Name);
                        this.FileDirectoryList[ChildDir.FullName].Add(ChildFileInfo.FullName);
                    }
                }
            }
