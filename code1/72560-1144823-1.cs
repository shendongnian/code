    class AccountService {
       private IDbConnection conn;
       internal AccountService(IDbConnection connection) {
         this.conn = connection;
       }
    
       public Account GetAccount(String id) {
         IDbCommand command = conn.CreateCommand();
         conn.Open;
         Account a = Account.FromReader(command.Execute(Strings.AccountSelect(id)));
         conn.Close;  // I remembered to call Close here
         return a;
       }
       // ... other methods where I Open() and Close() conn
       // hopefully not necessary since I've been careful to call .Close(), but just in case I forgot or an exception occured
       ~AccountService() { 
         if (conn != null) 
         {
           if (conn.State == System.Data.ConnectionState.Open)
           {
             conn.Close(); 
           }
           conn.Dispose();
         }
         conn = null;
       }
    }
If you had used  using, you wouldn't have even needed to think about using a Finalizer:
    // IDbFactory is custom, and used to retrieve a Connection for a given Database
    interface IDbFactory {
        IDbConnection Connection { get; }
    }
    
    class AccountService {
      private IDbFactory dbFactory; 
      internal AccountService(IDbFactory factory) { 
        this.dbFactory = factory;
      }
    
      public Account GetAccount(String id) {
        using (IDbConnection connection = dbFactory.Connection) { 
          using (command = connection.GetCommand()) {
            connection.Open();
            return Account.FromReader(command.Execute(Strings.AccountSelect(id)));
          } 
        } // via using, Close and Dispose are automatically called
      }
      // I don't need a finalizer, because there's nothing to close / clean up
    }
There are exceptions to the using rule, especially if the construction of the disposable object is expensive, but 99 times out of 100, if you're not using using, there's a smell.
