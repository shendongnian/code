    class Program
    {        
    
            static void Main(string[] args)
            {
                string SourceFolderPath = "D:\\SourcePath";
                string DestinationFolderPath = "D:\\DestinationPath";
                FileSystemWatcher FileSystemWatcher = new FileSystemWatcher();
                FileSystemWatcher.Path = SourceFolderPath;
                FileSystemWatcher.IncludeSubdirectories = false;
                FileSystemWatcher.NotifyFilter = NotifyFilters.FileName;   // ON FILE NAME FILTER       
                FileSystemWatcher.Filter = "*.txt";         
                 FileSystemWatcher.Created +=FileSystemWatcher_Created; // TRIGGERED ONLY FOR FILE GOT CREATED  BY COPY, CUT PASTE, MOVE  
                FileSystemWatcher.EnableRaisingEvents = true;
    			
                Console.Read();
            }     
    
            static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
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
    }
