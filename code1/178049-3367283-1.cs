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
