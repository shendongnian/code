    Server server = GetServer();
             if (server != null)
            {
                Database db = server.Databases[Settings.Instance.GetSetting("Database", "MyDB")];
                if (db != null)
                {
                    server.KillAllProcesses(db.Name);
                    db.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                    db.Alter(TerminationClause.RollbackTransactionsImmediately);
