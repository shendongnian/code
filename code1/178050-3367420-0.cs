    public abstract class DBServer
    {
        public List<Database> Databases { get; set; }
        // Non-virtual; the actual implementation is not done in that method anyway
        public bool MakeBackupCall(Database d)
        {
            return MakeBackupCallCore(d);
        }
    
        // Actual implementation goes there
        protected abstract MakeBackupCallCore(Database d);
    }
    public class RackspaceServer : DBServer
    {
        // Hide the base method
        public new bool MakeBackupCall(BackspaceDatabase d)
        {
            return MakeBackupCallCore(d);
        }
        // Do the actual implementation here, and ensure it is really a BackspaceDatabase
        protected virtual bool MakeBackupCallCore(Database d)
        {
            BackspaceDatabase bd = d as BackspaceDatabase;
            if (bd == null)
                throw new ArgumentException("d must be a BackspaceDatabase");
            // do some different stuff with bd
            return true;
        }
    }
