    public class Db<T> where T : IDbConnection, new()
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
            //get comm object from S conn
            using(var conn = new S())
                using (var comm = conn.CreateCommand())
            //...
        }
