     public class RepositoryFactory
     {
        ISettings settings;
        public RepositoryFactory (ISettings settings)
        {
           this.settings = settings;
        }
        ...
       public IRepo GetRepository(DataSource repositoryType)
       {
          ...
              return new CsvRepository(this.settings);
       }
