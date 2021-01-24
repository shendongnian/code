     public class RepositoryFactory
        {
            public static IRepository<IBasic> GetRepository(DataSource repositoryType)
            {
                IRepository<IBasic> repo = null;
                switch (repositoryType)
                {
                   
                    //break;
                    case DataSource.Csv:
                        repo = new CsvRepository();
                        break;
                    case DataSource.Oracle:
                        repo = new OracleRepository();
                        break;
                    default:
                        throw new ArgumentException("Invalid Repository Type");
                }
    
                return repo;
            }
        }
