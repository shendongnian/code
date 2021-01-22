    public abstract class DBServer<TDatabase> where TDatabase : Database
     {
      public List<TDatabase> Databases { get; set; }
      public abstract bool MakeBackupCall( TDatabase d );
     }
    
     public class DASPServer : DBServer<DASPDatabase>
     {
      public string APIKey { get; set; }
    
      public override bool MakeBackupCall( DASPDatabase d )
      {
       // do some stuff
       return true;
      }
     }
    
     public class RackspaceServer : DBServer<RackspaceDatabase>
     {
      public override bool MakeBackupCall( RackspaceDatabase d )
      {
       // do some different stuff
       return true;
      }
     }
    
     public abstract class Database
     {
      public string Name { get; set; }
     }
    
     public class DASPDatabase : Database
     {
      public string Version { get; set; }
     }
    
     public class RackspaceDatabase : Database
     {
      public string ServerName { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }
    
      protected string ConnectionString
      {
       get { return string.Format( "Data Source={0};Network Library=;Connection Timeout=30;Packet Size=4096;Integrated Security=no;Encrypt=no;Initial Catalog={1};User ID={2};Password={3}", ServerName, Name, UserName, Password ); }
      }
     }
