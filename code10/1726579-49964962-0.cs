    public async void Migrate()
    {
        var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        var fileName = "Tasks.db";
        var dbFullPath = dbFolder+"\\"+fileName;
        mainContext = new TaskContext(dbFullPath);
        await mainContext.Database.MigrateAsync();
    }
