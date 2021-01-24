        string GetDBPath();
    }
    public class  DBPathService : IDBPathService
    {
    
        public string GetDBPath()
        {
             return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDatabase.db");
        }
    }
