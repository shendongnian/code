    public class MyDB : DatabaseBase
    {
        public MyDB() : base(ConfigurationManager.AppSettings["MyConnectionString"])
        {
        }
    }
