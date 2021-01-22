    public class DBHelper<T, Y, W> where T: DbConnection, new() where Y : DbCommand, new()
    {
            private T conn_ = new T();
            private Y comm_ = new Y();            
    }
