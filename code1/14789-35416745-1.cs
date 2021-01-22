    class Program
    {
        static string IsSameFile = string.Empty;  // USE STATIC FOR TRACKING
        static void Main(string[] args)
        {
             string SourceFolderPath = "D:\\SourcePath";
            string DestinationFolderPath = "D:\\DestinationPath";
            FileSystemWatcher FileSystemWatcher = new FileSystemWatcher();
            FileSystemWatcher.Path = SourceFolderPath;
            FileSystemWatcher.IncludeSubdirectories = false;
            FileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;          
            FileSystemWatcher.Filter = "*.txt";         
            FileSystemWatcher.Changed += FileSystemWatcher_Changed;
            FileSystemWatcher.EnableRaisingEvents = true;
			
            Console.Read();
        }     
        static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.Name == IsSameFile)  //SKIPS ON MULTIPLE TRIGGERS
            {
                return;
            }
            else
            {
                string SourceFolderPath = "D:\\SourcePath";
                string DestinationFolderPath = "D:\\DestinationPath";
                try
                {
					// DO SOMETING LIKE MOVE, COPY, ETC
                    File.Copy(e.FullPath, DestinationFolderPath + @"\" + e.Name);
                }
                catch
                {
                }
            }
            IsSameFile = e.Name;
        }
