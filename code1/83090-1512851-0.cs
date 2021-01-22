public enum DBConnection
{
   DBTest1,
   DBTest2
}
public static class ConnectionStringManager
{
   static Exception _construtorException = null;
   static Dictionary<DBConnection, string> _connectionMap = new Dictionary<DBConnection, string>();
   
   static ConnectionStringManager()
   {
      try
      {
         // Load the _connectionMap
         // You can use a custom application configuration section or
         // connection strings defined as described in the following article
         // http://msdn.microsoft.com/en-us/library/bf7sd233.aspx
      }
      catch(Exception ex)
      {
         // Any exception thrown in a static constructor needs to be kept track of because static
         // constructors are called during type initialization and exceptions thrown
         // are not caught by normal application exception handling. 
         // (At least as of .NET 2.0)
         _constructorException = ex;
      }
   }
   
   public static string GetConnectionString(DBConnection conn)
   {
      if ( _constructorEx != null )
         throw new Exception("Error initializing ConnectionStringManager", _constructorException);
   
      if ( !_connectionMap.ContainsKey(conn) )
         throw new Exception(string.Format("Connection {0} not found", Enum.GetName(typeof(DBconnection), (int)conn));
         
      return _connectionMap[conn];
   }
}
