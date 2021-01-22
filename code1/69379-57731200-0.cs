    public class ManageFile {
       private readonly IFileSystem _fileSystem;
       public ManageFile(IFileSystem fileSystem){
      
          _fileSystem = fileSystem;
       }
       public bool FileExists(string filePath){}
           if(_fileSystem.File.Exists(filePath){
              return true;
           }
           return false;
       }
    }
