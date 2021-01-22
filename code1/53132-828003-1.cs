    class Program 
    {
        static void Main(string[] args)
        {
            Program shell = new Program();
    
            shell.doDatabaseWork();
        }
    
        private void doDatabaseWork()
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
