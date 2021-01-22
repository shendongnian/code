    public void DeleteDirectoryFolders(DirectoryInfo dirInfo){
        foreach (DirectoryInfo dirs in dir.GetDirectories()) 
        { 
            dirs.Delete(true); 
        } 
    }
    
    public void DeleteDirectoryFiles(DirectoryInfo dirInfo) {
        foreach(FileInfo files in dir.GetFiles()) 
        { 
            files.Delete(); 
        } 
    }
    
    public void DeleteDirectoryFilesAndFolders(string dirName) {
      DirectoryInfo dir = new DirectoryInfo(dirName); 
      DeleteDirectoryFiles(dir)
      DeleteDirectoryFolders(dir)
    }
    
    public void main() {
      List<string> DirectoriesToDelete;
      DirectoriesToDelete.add("c:\temp");
      DirectoriesToDelete.add("c:\temp1");
      DirectoriesToDelete.add("c:\temp2");
      DirectoriesToDelete.add("c:\temp3");
      foreach (string dirName in DirectoriesToDelete) {
        DeleteDirectoryFilesAndFolders(dirName);
      }
    }
