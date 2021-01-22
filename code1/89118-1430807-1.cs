    public class MyDB : DatabaseBase
    {
        static readonly string connectionString = 
              ConfigurationManager.AppSettings["MyConnectionString"];
        public MyDB() : base(connectionString)
        {
        }
    }
