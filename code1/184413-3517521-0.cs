    public class CatalogFactory {
      public ICatalog CreateCatalog(string location, bool openReadOnly)
      {
        if(location is filePath)
        {
            return OpenFileCatalog(string location, bool openReadOnly);
        }
        else if(location is SQL server)
        {
            return OpenSqlCatalog(string location, bool openReadOnly);
        }
        else
        {
            throw new ArgumentException("Unknown catalog type","location");
        }
      }
      FileSystemCatalog OpenFileCatalog(string location, bool openReadOnly) {
        return new FileSystemCatalog{/*init*/};
      }
      SqlCatalog OpenSqlCatalog(string location, bool openReadOnly) {
        return new SqlCatalog{/*init*/};
      }
    }
