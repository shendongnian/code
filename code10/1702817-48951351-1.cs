    using SQLite.Net.Async;
        private SQLiteConnectionWithLock GetAsyncConnection()
        {
            var localFolder = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(localFolder, FileName);
            var connString = new SQLiteConnectionString(path, true);
            var conn = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), connString);
            return conn;
        }
        public async Task<FFSystems> ReadFFSystemAsync(int FFSystemID)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(() => GetAsyncConnection());
            return await conn.Table<FFSystems>().Where(s => s.ID ==FFSystemID).FirstOrDefaultAsync();
        }
