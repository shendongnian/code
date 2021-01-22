    public static class StorageFactory
    {
       public static IFileStorage GetStorage(FileStorageTypes types)
       {
          switch(types)
          {
             case FileStorageTypes.Database: return new DatabaseStorage();
             case FileStorageTypes.FileSystem: return new FileStorage();
          }
       }
    }
