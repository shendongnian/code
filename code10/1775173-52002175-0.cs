    public class SharedDatabaseSession
    {
        private bool commitRequired;
        private DatabaseConnection databaseConnection;
    
        // ....
        public void Write( /*xyz*/)
        {            
            databaseConnection.Write( /*xyz*/);
            commitRequired = true;
        }
        public void Commit()
        {
            if (commitRequired)
            {
                databaseConnection.Commit();
                commitRequired = false;
            }
        }
        public static SharedDatabaseSession GetInstance()
        {
            return instance;
        }
    }
    public class FirstCacheStore : CacheStoreAdapter<int, int>
    {
        private SharedDatabaseSession database = SharedDatabaseSession.GetInstance();
        /// ...... 
        public override void Write(int key, int val)
        {
            database.Write( /*xyz*/);
        }
        public override void SessionEnd(bool commit)
        {
            if (commit)
            {
                database.Commit();
            }
        }
    }
    public class SecondCacheStore : CacheStoreAdapter<int, int>
    {
        private SharedDatabaseSession database = SharedDatabaseSession.GetInstance();
        /// ...... 
        public override void Write(int key, int val)
        {
            database.Write( /*xyz*/);
        }
        public override void SessionEnd(bool commit)
        {
            if (commit)
            {
                database.Commit();
            }
        }
    }
