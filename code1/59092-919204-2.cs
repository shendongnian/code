    public PictureDataService: IPictureDataService
    {
      public PictureDataService(RepositoryFactory repositoryFactory, LoaderFactory loaderFactory)
      {
         _repositoryFactory = repositoryFactory;
         _loaderFactory = loaderFactory;
      }
    
      private readonly RepositoryFactory _repositoryFactory;
      private readonly LoaderFactory _loaderFactory;
      private PictureDataRepository _repo;
      private PictureDataLoader _loader;
    
      public void Save(UserAccount account, UserSubmittedFile file)
      {
        #region Validation
        if (account == null) throw new ArgumentNullException("account");
        if (file == null) throw new ArgumentNullException("file");
        #endregion
    
        using (PictureDataRepository repo = getRepository())
        using (PictureDataLoader loader = getLoader())
        {
          PictureData pictureData = loader.GetPictureData(file);
          pictureData.For(account);
          repo.Save(pictureData);
        } // Any exceptions cause repo and loader .Dispose() methods 
          // to be called, cleaning up their resources...the exception
          // bubbles up to the client
      }
    
      private PictureDataRepository getRepository()
      {
        if (_repo == null)
        {
          _repo = _repositoryFactory.GetPictureDataRepository();
        }
    
        return _repo;
      }
    
      private PictureDataLoader getLoader()
      {
        if (_loader == null)
        {
            _loader = _loaderFactory.GetPictureDataLoader();
        }
    
        return _loader;
      }
    }
    
    public class PictureDataRepository: IDisposable
    {
      public PictureDataRepository(ConnectionFactory connectionFactory)
      {
      }
    
      private readonly ConnectionFactory _connectionFactory;
      private Connection _connection;
    
      // ... repository implementation ...
    
      public void Dispose()
      {
        GC.SuppressFinalize(this);
    
        _connection.Close();
        _connection = null; // 'detatch' from this object so GC can clean it up faster
      }
    }
    
    public class PictureDataLoader: IDisposable
    {
      // ... Similar implementation as PictureDataRepository ...
    }
