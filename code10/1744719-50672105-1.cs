    public class DatabaseConnection_Droid : IDatabaseConnection
    {
        public SQLiteAsyncConnection AsyncDbConnection()
        {
            var dbName = "DiceyData.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteAsyncConnection(path);
        }
    }
