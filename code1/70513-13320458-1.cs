    public class Db<S, T> where S : IDbConnection, new() where T : IDbCommand, new()
    {
        public bool CreateConnection()
        {
            T conn;
    
            //now you dont need these lines since you dont have to worry about
            //what type of db you are using here, since they all implement
            //IDbConnection, and in your case its just T.
            //if(type==DatabaseTye.Oracle)
            //{
                //....
            //}
        }
    
        public DbDataReader GetData()
        {
            S comm;
            //...
        }
