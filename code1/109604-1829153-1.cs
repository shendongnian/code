    public class SyncedDbCommand : DbCommand
    {
        private DbCommand _cmd;
        private object _sync;
    
        public SyncedDbCommand(DbCommand cmd, object sync)
        {
            _cmd = cmd;
            _sync = sync;
        }
    
        // omitted basic proxy method overrides
    
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            Monitor.Enter(_sync);
            return _cmd.ExecuteReader();
        }
    
        public override int ExecuteNonQuery()
        {
            Monitor.Enter(_sync);
            return _cmd.ExecuteNonQuery();
        }
    
        public override object ExecuteScalar()
        {
            Monitor.Enter(_sync);
            return _cmd.ExecuteScalar();
        }
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Monitor.Exit(_sync);
            }
            base.Dispose(disposing);
        }
    }
