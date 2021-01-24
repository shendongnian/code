    public interface IAccountDataAccess 
    {
      IEnumerable<Account> GetAccountsHigherThanBalance(Status status, Balance balance);
      // etc.
    }
    
    public class JsonAccountDataAccess : IAccountDataAccess 
    {
      
      private string jsonFilePath;
      public JsonAccountDataAccess(string _jsonFilePath)
      {
        jsonFilePath = _jsonFilePath;
      }
     
      public IEnumerable<Account> GetAccountsHigherThanBalance(Status status, Balance balance) 
      {
        // read json file, extract data, etc.
      }
    }
    public class DatabaseAccountDataAccess : IAccountDataAccess 
    {
      
      private string connectionString;
      public DatabaseAccountDataAccess(string _connectionString)
      {
        connectionString = _connectionString;
      }
     
      public IEnumerable<Account> GetAccountsHigherThanBalance(Status status, Balance balance) 
      {
        // read database, extract data, etc.
      }
    }
