    public class DataBase
    {
        public void AccessDB()
        {
            // Do logic here before closing connection
            CloseConnection();
        }
    
        protected virtual void CloseConnection()
        {
            // Real Logic to close connection
        }
    }
    
    public class FakeDataBase : DataBase
    {
        ManualResetEvent sychObject;
    
        public FakeDataBase(ManualResetEvent sychObject)
        {
            this.sychObject = sychObject;
        }
    
        override protected void CloseConnection()
        {
            sychObject.WaitOne();
            base.CloseConnection();
        }
    }
