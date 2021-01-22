    public class Db<S, T> where S : IDbConnection, new() where T : IDbCommand, new()
    {
        public bool CreateConnection(DatabaseTypeEnum type)
        {
            T conn;
    
            if(type==DatabaseTye.Oracle)
            {
                //....
            }    
        }
    
        public DbDataReader GetData()
        {
            S comm;
            //...
        }
