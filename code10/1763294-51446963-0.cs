    public interface IFolderPathProvider {
        string GetFolderPath();
        void SetFolderPath(string);
    }
    public class FolderPathProvider : IFolderPathProvider  {
        ...
    }
    public class FolderService : IService
    {
      private IFolderPathProvider _folderPathProvider;
    
      public FolderService(IFolderPathProvider folderPathProvider)
      {
        _folderPathProvider = folderPathProvider;
      }
    
      public string FindSomeData()
      {
        string path = _folderPathProvider.GetFolderPath();
        //Open a folder using path and find some data
      }
    }
