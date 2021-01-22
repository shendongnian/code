    class Program 
    {
        static void Main(string[] args)
        {
            DBWorker worker = new DBWorker();
            worker.DoDatabaseWork();
        }
    }
    public class DBWorker 
    {
        private void DoDatabaseWork()
        {
            using (SQLiteConnection sourceDB = new SQLiteConnection( GetConnectionString() ))
            {
                sourceDB.Open();
                using (SQLiteConnection destDB = new SQLiteConnection( GetConnectionString() ))
                {
                    destDB.Open();
                }
            }
        }
    }
