        public void AddToGoogle()
        {
            var client = new DatabaseClient(Settings.Default.GmailAccount, Settings.Default.GmailPassword);
            string dbName = Settings.Default.WorkBook;
            var db = client.GetDatabase(dbName) ?? client.CreateDatabase(dbName);
            string tableName = Settings.Default.WorkSheet;
            var t = db.GetTable<ActivityLog>(tableName) ?? db.CreateTable<ActivityLog>(tableName);
            var all = t.FindAll();
            t.Add(this);
        }
