    static void DumpDatabase()
    {
        var dbFullPath = Utility.GetDbFullPath();
        if (File.Exists(dbFullPath))
            return; //whatever your logic is
        CreateDb(dbFullPath);
    }
    static void Create(string dbFullPath)
    {
        SQLiteConnection.CreateFile(dbFullPath);
        string query = @"
        CREATE TABLE [haha] (.............)
        CREATE TABLE ..............";
        
        Execute(query);
    }
